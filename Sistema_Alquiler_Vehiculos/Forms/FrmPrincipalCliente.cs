// ─────────────────────────────────────────────────────────────────────────────
// Archivo  : FrmPrincipalCliente.cs
// Capa     : Forms (Presentación)
// Propósito: Formulario principal del cliente. Permite ver vehículos
//            disponibles, alquileres, pagos y perfil.
// ─────────────────────────────────────────────────────────────────────────────

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Sistema_Alquiler_Vehiculos.BLL;
using Sistema_Alquiler_Vehiculos.DAL;

namespace Sistema_Alquiler_Vehiculos.Forms
{

    // Formulario principal del cliente.
    public partial class FrmPrincipalCliente : Form
    {
        // ─────────────────────────────────────────────────────────────────
        // Atributos
        // ─────────────────────────────────────────────────────────────────

        // Usuario que inició sesión. Se usa para cargar sus datos.
        private readonly Usuarios _usuarioActivo;

        // Facade de vehiculos para obtener los disponibles.
        private readonly VehiculoFacade _vehiculoFacade;

        // Facade de alquileres para obtener los alquileres del cliente.
        private readonly AlquilerFacade _alquilerFacade;

        // Facade de pagos para obtener los pagos del cliente.
        private readonly PagoFacade _pagoFacade;

        // ─────────────────────────────────────────────────────────────────
        // Constructor
        // ─────────────────────────────────────────────────────────────────

        // Inicializa el formulario recibiendo el usuario activo desde el login.
        public FrmPrincipalCliente(Usuarios usuarioActivo)
        {
            InitializeComponent();
            _usuarioActivo = usuarioActivo;
            _vehiculoFacade = new VehiculoFacade();
            _alquilerFacade = new AlquilerFacade();
            _pagoFacade = new PagoFacade();
        }

        // ─────────────────────────────────────────────────────────────────
        // Eventos del formulario
        // ─────────────────────────────────────────────────────────────────

        // Configura el formulario al cargar.
        private void FrmPrincipalCliente_Load(object sender, EventArgs e)
        {
            lblBienvenida.Text = $"Bienvenido, {_usuarioActivo.Nombre} {_usuarioActivo.Apellido}";
            CargarVehiculos();
        }

        // ─────────────────────────────────────────────────────────────────
        // Eventos del menú
        // ─────────────────────────────────────────────────────────────────

        // Muestra los vehículos disponibles en el área principal.
        private void btnVehiculos_Click(object sender, EventArgs e)
        {
            CargarVehiculos();
        }

        // Muestra los alquileres del cliente en el área principal.
        private void btnAlquileres_Click(object sender, EventArgs e)
        {
            CargarAlquileres();
        }

        // Muestra los pagos del cliente en el área principal.
        private void btnPagos_Click(object sender, EventArgs e)
        {
            CargarPagos();
        }

        // Abre el formulario de perfil del cliente para ver y editar su información personal.
        private void btnPerfil_Click(object sender, EventArgs e)
        {
            // Por implementar
            MessageBox.Show("Modulo de perfil proximamente.", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Cierra la sesión y vuelve al formulario de inicio de sesión.
        private void btnSalir_Click(object sender, EventArgs e)
        {
            var confirmacion = MessageBox.Show(
                "¿Estas seguro que deseas cerrar sesion?",
                "Cerrar sesion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
                this.Close();
        }

        // Filtra los vehiculos por la marca ingresada en el comboBox.
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (cmbMarca.SelectedIndex == 0)
            {
                CargarVehiculos();
                return;
            }

            string marca = cmbMarca.SelectedItem.ToString();
            var vehiculos = _vehiculoFacade.ObtenerDisponiblesPorMarca(marca);

            MostrarVehiculos(vehiculos);
        }

        // Limpia el filtro y muestra todos los vehículos disponibles.
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cmbMarca.SelectedIndex = 0;
            CargarVehiculos();
        }

        // Abre el formulario de alquiler para el vehículo seleccionado.
        private void dgvVehiculos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            AbrirAlquiler();
        }

        // Maneja el clic en la celda del botón Alquilar para abrir el formulario de alquiler.
        private void dgvVehiculos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dgvVehiculos.Columns[e.ColumnIndex].Name != "Alquilar") return;

            AbrirAlquiler();
        }

        // ─────────────────────────────────────────────────────────────────
        // Métodos privados
        // ─────────────────────────────────────────────────────────────────

        // Carga los vehículos disponibles en el panel principal.
        private void CargarVehiculos()
        {
            pnlFiltros.Visible = true;
            var vehiculos = _vehiculoFacade.ObtenerDisponibles();
            MostrarVehiculos(vehiculos);

            // Llena el ComboBox de marcas
            cmbMarca.Items.Clear();
            cmbMarca.Items.Add("Todas");
            foreach (var marca in _vehiculoFacade.ObtenerMarcasDisponibles())
                cmbMarca.Items.Add(marca);
            cmbMarca.SelectedIndex = 0;
        }

        // Carga los alquileres del cliente en el panel principal.
        private void CargarAlquileres()
        {
            LimpiarColumnasExtra();
            pnlFiltros.Visible = false;

            var alquileres = _alquilerFacade.ObtenerPorCliente(_usuarioActivo.UsuarioId);

            dgvVehiculos.DataSource = null;

            if (alquileres.Count == 0)
            {
                MessageBox.Show(
                    "No tienes alquileres registrados.",
                    "Sin resultados",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            dgvVehiculos.DataSource = alquileres.Select(a => new
            {
                a.AlquilerId,
                Vehiculo = a.Vehiculos.Marca + " " + a.Vehiculos.Modelo,
                a.FechaInicio,
                FechaFin = a.FechaFinPactada,
                FechaDevolucion = a.FechaDevolucion.HasValue
                                  ? a.FechaDevolucion.Value.ToShortDateString()
                                  : "Pendiente",
                Estado = a.EstadosAlquiler.NombreEstado,
                a.MultaRetraso,
                a.CostoDanios
            }).ToList();

            dgvVehiculos.Columns["AlquilerId"].HeaderText = "ID";
            dgvVehiculos.Columns["Vehiculo"].HeaderText = "Vehiculo";
            dgvVehiculos.Columns["FechaInicio"].HeaderText = "Inicio";
            dgvVehiculos.Columns["FechaFin"].HeaderText = "Fin Pactado";
            dgvVehiculos.Columns["FechaDevolucion"].HeaderText = "Devolucion";
            dgvVehiculos.Columns["Estado"].HeaderText = "Estado";
            dgvVehiculos.Columns["MultaRetraso"].HeaderText = "Multa";
            dgvVehiculos.Columns["CostoDanios"].HeaderText = "Danios";

            dgvVehiculos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // Carga los pagos del cliente en el panel principal.
        private void CargarPagos()
        {
            LimpiarColumnasExtra();
            pnlFiltros.Visible = false;

            var pagos = _pagoFacade.ObtenerPorCliente(_usuarioActivo.UsuarioId);

            dgvVehiculos.DataSource = null;

            if (pagos.Count == 0)
            {
                MessageBox.Show(
                    "No tienes pagos registrados.",
                    "Sin resultados",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            dgvVehiculos.DataSource = pagos.Select(p => new
            {
                p.PagoId,
                Vehiculo = p.Alquileres.Vehiculos.Marca + " " + p.Alquileres.Vehiculos.Modelo,
                p.Monto,
                p.FechaPago,
                p.EstadoPago
            }).ToList();

            dgvVehiculos.Columns["PagoId"].HeaderText = "ID";
            dgvVehiculos.Columns["Vehiculo"].HeaderText = "Vehiculo";
            dgvVehiculos.Columns["Monto"].HeaderText = "Monto";
            dgvVehiculos.Columns["FechaPago"].HeaderText = "Fecha";
            dgvVehiculos.Columns["EstadoPago"].HeaderText = "Estado";


            dgvVehiculos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // Muestra los vehículos en el DataGridView, proyectando solo las columnas necesarias y agregando un botón de alquiler.
        private void MostrarVehiculos(List<Vehiculos> vehiculos)
        {
            dgvVehiculos.DataSource = null;

            if (vehiculos.Count == 0)
            {
                MessageBox.Show(
                    "No hay vehiculos disponibles con ese filtro.",
                    "Sin resultados",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            // Proyecta solo las columnas que queremos mostrar
            dgvVehiculos.DataSource = vehiculos.Select(v => new
            {
                v.VehiculoId,
                v.Placa,
                v.Marca,
                v.Modelo,
                v.Anio,
                Tipo = v.TiposVehiculo.NombreTipo,
                Estado = v.EstadosVehiculo.NombreEstado
            }).ToList();

            // Renombra las columnas
            dgvVehiculos.Columns["VehiculoId"].HeaderText = "ID";
            dgvVehiculos.Columns["Placa"].HeaderText = "Placa";
            dgvVehiculos.Columns["Marca"].HeaderText = "Marca";
            dgvVehiculos.Columns["Modelo"].HeaderText = "Modelo";
            dgvVehiculos.Columns["Anio"].HeaderText = "Año";
            dgvVehiculos.Columns["Tipo"].HeaderText = "Tipo";
            dgvVehiculos.Columns["Estado"].HeaderText = "Estado";

            // Oculta el ID
            dgvVehiculos.Columns["VehiculoId"].Visible = false;

            // Ajusta el ancho de las columnas
            dgvVehiculos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Agrega columna de botón Alquilar
            if (dgvVehiculos.Columns["Alquilar"] == null)
            {
                var btnAlquilar = new DataGridViewButtonColumn
                {
                    Name = "Alquilar",
                    HeaderText = "Alquilar",
                    Text = "Alquilar",
                    UseColumnTextForButtonValue = true,
                    Width = 80
                };
                dgvVehiculos.Columns.Add(btnAlquilar);
            }

            // Siempre mantiene la columna Alquilar al final
            dgvVehiculos.Columns["Alquilar"].DisplayIndex = dgvVehiculos.Columns.Count - 1;
        }

        // Abre el formulario de alquiler para el vehículo seleccionado.
        private void AbrirAlquiler()
        {
            if (dgvVehiculos.SelectedRows.Count == 0) return;

            // Obtiene el ID del vehículo seleccionado
            int vehiculoId = Convert.ToInt32(dgvVehiculos.SelectedRows[0].Cells["VehiculoId"].Value);

            // Obtiene el vehículo completo desde la Facade
            var vehiculo = _vehiculoFacade.ObtenerPorId(vehiculoId);

            if (vehiculo == null) return;

            // Abre el formulario de alquiler
            var frm = new FrmRegistrarAlquiler(vehiculo, _usuarioActivo, _alquilerFacade);
            frm.ShowDialog();

            // Refresca la lista de vehículos al cerrar
            CargarVehiculos();
        }

        // Limpia las columnas extra del DGV antes de cargar un nuevo modulo.
        private void LimpiarColumnasExtra()
        {
            if (dgvVehiculos.Columns["Alquilar"] != null)
                dgvVehiculos.Columns.Remove("Alquilar");
        }
    }
}
