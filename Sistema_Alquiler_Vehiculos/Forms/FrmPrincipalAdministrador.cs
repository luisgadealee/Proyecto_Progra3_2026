// ─────────────────────────────────────────────────────────────────────────────
// Archivo  : FrmPrincipalAdministrador.cs
// Capa     : Forms (Presentación)
// Propósito: Formulario principal del administrador. Permite gestionar
//            solicitudes pendientes, devoluciones, vehículos y reportes.
// ─────────────────────────────────────────────────────────────────────────────

using Sistema_Alquiler_Vehiculos.BLL;
using Sistema_Alquiler_Vehiculos.DAL;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Sistema_Alquiler_Vehiculos.Forms
{
    public partial class FrmPrincipalAdministrador : Form
    {

        // ─────────────────────────────────────────────────────────────────
        // Atributos
        // ─────────────────────────────────────────────────────────────────

        // Almacena el usuario administrador que inició sesión
        private readonly Usuarios _usuarioActivo;

        // Facade para comunicarse con la base de datos de alquileres
        private readonly AlquilerFacade _alquilerFacade;

        // ─────────────────────────────────────────────────────────────────
        // Constructor
        // ─────────────────────────────────────────────────────────────────
        public FrmPrincipalAdministrador(Usuarios usuarioActivo)
        {
            InitializeComponent();
            _usuarioActivo = usuarioActivo;
            _alquilerFacade = new AlquilerFacade();
        }

        // ─────────────────────────────────────────────────────────────────
        // Eventos del formulario
        // ─────────────────────────────────────────────────────────────────

        // Inicializa el formulario y recibe el usuario que hizo login
        private void FrmPrincipalAdministrador_Load(object sender, EventArgs e)
        {
            // ─────────────────────────────────────────────────────────────────
            // Lógica de Control de Acceso (RBAC)
            // ─────────────────────────────────────────────────────────────────

            // 1. Vendedor (Rol 2)
            if (_usuarioActivo.RolId == 2)
            {
                btnVehiculos.Visible = false; // No gestiona flota
                btnClientes.Visible = false;  // No gestiona base de datos de clientes
                btnReportes.Visible = false;  // No ve finanzas
                btnEmpleados.Visible = false; // No ve otros empleados
            }
            // 2. Administrador (Rol 3)
            else if (_usuarioActivo.RolId == 3)
            {
                btnEmpleados.Visible = false; // El admin gestiona todo menos a otros empleados
            }
            // 3. Super Usuario (Rol 4)
            else if (_usuarioActivo.RolId == 4)
            {
                // Tiene acceso total, no ocultamos nada
                btnEmpleados.Visible = true;
            }

            lblBienvenida.Text = $"Bienvenido/a: {_usuarioActivo.Nombre} ({ObtenerNombreRol(_usuarioActivo.RolId)})";
        }

        // ─────────────────────────────────────────────────────────────────
        // Eventos del Menú Lateral
        // ─────────────────────────────────────────────────────────────────

        // Evento al hacer clic en el botón de "Solicitudes"
        private void btnSolicitudes_Click(object sender, EventArgs e)
        {
            CargarSolicitudesPendientes();
        }

        // Evento al hacer clic en el botón de "Salir"
        private void btnSalir_Click(object sender, EventArgs e)
        {
            // Pregunta antes de cerrar sesión
            var confirmacion = MessageBox.Show(
                "¿Deseas cerrar sesión?",
                "Cerrar sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                this.Close();
            }
        }

        // Evento para cargar el historial de auditoría
        private void btnDevoluciones_Click(object sender, EventArgs e)
        {
            CargarAlquileresActivos();
        }
        // Evento para abrir el formulario de gestión de vehículos
        private void btnVehiculos_Click(object sender, EventArgs e)
        {
            var frm = new FrmVehiculos();
            frm.ShowDialog();
            // Usamos ShowDialog para que el admin no pueda tocar la ventana 
            // principal hasta que cierre la de vehículos
        }

        // Evento para abrir el formulario de gestión de clientes
        private void btnClientes_Click(object sender, EventArgs e)
        {
            var frm = new FrmClientes();
            frm.ShowDialog();
        }

        // Evento para abrir el formulario de reportes financieros
        private void btnReportes_Click(object sender, EventArgs e)
        {
            var frm = new FrmReportes();
            frm.ShowDialog();
        }

        // Evento para abrir el formulario de gestión de empleados (solo para Super Usuario)
        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            var frm = new FrmEmpleados();
            frm.ShowDialog();
        }

        // ─────────────────────────────────────────────────────────────────
        // Eventos del DataGridView
        // ─────────────────────────────────────────────────────────────────
        private void dgvAdmin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Si el clic fue en el encabezado de la tabla (fuera de los datos), lo ignora
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            // Obtiene el nombre de la columna donde se hizo clic
            string nombreColumna = dgvAdmin.Columns[e.ColumnIndex].Name;

            // Obtiene el ID del alquiler de la fila seleccionada
            int alquilerId = Convert.ToInt32(dgvAdmin.Rows[e.RowIndex].Cells["AlquilerId"].Value);

            // Si hizo clic en el botón "Aprobar"
            if (nombreColumna == "Aprobar")
            {
                var confirmacion = MessageBox.Show(
                    "¿Estás seguro de APROBAR esta solicitud?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    // Llama a la capa BLL para aprobar
                    _alquilerFacade.AprobarAlquiler(alquilerId, _usuarioActivo.UsuarioId);

                    MessageBox.Show(
                        "Alquiler aprobado. El vehículo ahora está marcado como Alquilado.",
                        "Éxito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // Recarga la tabla para que desaparezca la solicitud que ya procesamos
                    CargarSolicitudesPendientes();
                }
            }
            // Si hizo clic en el botón "Rechazar"
            else if (nombreColumna == "Rechazar")
            {
                var confirmacion = MessageBox.Show(
                    "¿Estás seguro de RECHAZAR esta solicitud?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmacion == DialogResult.Yes)
                {
                    // Llama a la capa BLL para rechazar
                    _alquilerFacade.RechazarAlquiler(alquilerId);

                    MessageBox.Show(
                        "Alquiler rechazado.",
                        "Éxito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // Recarga la tabla para reflejar el cambio
                    CargarSolicitudesPendientes();
                }
            }
            // Si hizo clic en el botón "Registrar" (Devolución)
            else if (nombreColumna == "Registrar")
            {
                // Buscamos el alquiler completo en la base de datos
                var alquiler = _alquilerFacade.ObtenerPorId(alquilerId);

                if (alquiler != null)
                {
                    // Abrimos el formulario modal pasando los datos
                    var frm = new FrmRegistrarDevolucion(alquiler, _alquilerFacade);
                    frm.ShowDialog();

                    // Al cerrar el modal, recargamos la grilla para que el auto desaparezca de la lista
                    CargarAlquileresActivos();
                }
            }

        }

        // ─────────────────────────────────────────────────────────────────
        // Métodos Privados
        // ─────────────────────────────────────────────────────────────────

        // Carga y muestra en la grilla los alquileres que están en estado "Pendiente"
        private void CargarSolicitudesPendientes()
        {
            // Pide a la base de datos la lista de solicitudes pendientes
            var solicitudes = _alquilerFacade.ObtenerSolicitudesPendientes();

            // Si no hay solicitudes, muestra el mensaje amigable
            if (solicitudes.Count == 0)
            {
                dgvAdmin.DataSource = null;
                lblMensajeVacio.Text = "No hay solicitudes pendientes por aprobar.";
                lblMensajeVacio.Visible = true;
                lblMensajeVacio.BringToFront(); // Lo trae al frente por si el datagrid lo tapa
                return;
            }

            // Si hay datos, ocultamos el mensaje
            lblMensajeVacio.Visible = false;

            // Proyecta solo las columnas que el administrador necesita ver (Clean Code)
            dgvAdmin.DataSource = solicitudes.Select(a => new
            {
                a.AlquilerId,
                Cliente = a.Usuarios.Nombre + " " + a.Usuarios.Apellido,
                Vehiculo = a.Vehiculos.Marca + " " + a.Vehiculos.Modelo,
                Placa = a.Vehiculos.Placa,
                Inicio = a.FechaInicio.ToShortDateString(),
                FinPactado = a.FechaFinPactada.ToShortDateString()
            }).ToList();

            // Personaliza los títulos de las columnas básicas
            dgvAdmin.Columns["AlquilerId"].HeaderText = "ID";
            dgvAdmin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Crea dinámicamente el botón "Aprobar"
            var btnAprobar = new DataGridViewButtonColumn
            {
                Name = "Aprobar",
                HeaderText = "Acción",
                Text = "Aprobar ✔️",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat
            };
            btnAprobar.DefaultCellStyle.ForeColor = Color.DarkGreen; // Texto verde para aprobar

            // Agrega el botón de aprobar a la grilla
            dgvAdmin.Columns.Add(btnAprobar);

            // Crea dinámicamente el botón "Rechazar"
            var btnRechazar = new DataGridViewButtonColumn
            {
                Name = "Rechazar",
                HeaderText = "Acción",
                Text = "Rechazar ❌",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat
            };
            btnRechazar.DefaultCellStyle.ForeColor = Color.DarkRed; // Texto rojo para rechazar

            // Agrega el botón de rechazar a la grilla
            dgvAdmin.Columns.Add(btnRechazar);
        }

        // Carga en la DGV los autos que están actualmente en la calle (Estado 2)
        private void CargarAlquileresActivos()
        {
            dgvAdmin.Columns.Clear();

            var activos = _alquilerFacade.ObtenerAlquileresActivos();

            if (activos.Count == 0)
            {
                dgvAdmin.DataSource = null;
                lblMensajeVacio.Text = "No hay vehículos alquilados en la calle en este momento.";
                lblMensajeVacio.Visible = true;
                lblMensajeVacio.BringToFront();
                return;
            }

            lblMensajeVacio.Visible = false;

            // Proyecta las columnas
            dgvAdmin.DataSource = activos.Select(a => new
            {
                a.AlquilerId,
                Cliente = a.Usuarios.Nombre + " " + a.Usuarios.Apellido,
                Vehiculo = a.Vehiculos.Marca + " " + a.Vehiculos.Modelo,
                Placa = a.Vehiculos.Placa,
                FinPactado = a.FechaFinPactada.ToShortDateString()
            }).ToList();

            dgvAdmin.Columns["AlquilerId"].HeaderText = "ID";
            dgvAdmin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Botón para procesar la entrega
            var btnRegistrar = new DataGridViewButtonColumn
            {
                Name = "Registrar",
                HeaderText = "Acción",
                Text = "Recibir Auto 🚗",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat
            };
            btnRegistrar.DefaultCellStyle.ForeColor = Color.DarkBlue;
            dgvAdmin.Columns.Add(btnRegistrar);
        }

        private void CargarHistorialAuditoria()
        {
            dgvAdmin.Columns.Clear();
            var historial = _alquilerFacade.ObtenerHistorialCompleto();

            if (historial.Count == 0)
            {
                dgvAdmin.DataSource = null;
                lblMensajeVacio.Text = "No hay registros en el historial de auditoría.";
                lblMensajeVacio.Visible = true;
                lblMensajeVacio.BringToFront();
                return;
            }

            lblMensajeVacio.Visible = false;

            // ⚠️ ATENCIÓN INGENIERO: Aquí hay un truco avanzado de LINQ
            dgvAdmin.DataSource = historial.Select(a => new
            {
                a.AlquilerId,
                Cliente = a.Usuarios.Nombre + " " + a.Usuarios.Apellido,
                Vehiculo = a.Vehiculos.Marca + " " + a.Vehiculos.Modelo,
                Estado = a.EstadosAlquiler.NombreEstado,
                // Buscamos el nombre del admin directamente en la BD usando su ID
                ProcesadoPor = a.UsuarioAdminId.HasValue ? _alquilerFacade.ObtenerNombreAdmin(a.UsuarioAdminId.Value) : "Sistema",
                Multa = a.MultaRetraso.ToString("C2"),
                Danios = a.CostoDanios.ToString("C2")
            }).ToList();

            dgvAdmin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // Método auxiliar para mostrar el nombre del cargo
        private string ObtenerNombreRol(int? rolId)
        {
            switch (rolId)
            {
                case 2: return "Vendedor";
                case 3: return "Administrador";
                case 4: return "Director General";
                default: return "Usuario";
            }
        }

        
    }
}
