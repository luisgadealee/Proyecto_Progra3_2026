// ─────────────────────────────────────────────────────────────────────────────
// Archivo  : FrmRegistrarAlquiler.cs
// Capa     : Forms (Presentación)
// Propósito: Formulario para registrar un nuevo alquiler.
//            Recibe el vehículo y el usuario desde el formulario principal.
// ─────────────────────────────────────────────────────────────────────────────

using Sistema_Alquiler_Vehiculos.BLL;
using Sistema_Alquiler_Vehiculos.DAL;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Sistema_Alquiler_Vehiculos.Forms
{
    public partial class FrmRegistrarAlquiler : Form
    {
        // ─────────────────────────────────────────────────────────────────
        // Atributos
        // ─────────────────────────────────────────────────────────────────

        // Facade de alquileres para registrar el alquiler.
        private readonly AlquilerFacade _alquilerFacade;

        // Vehiculo seleccionado desde el formulario principal.
        private readonly Vehiculos _vehiculo;

        // Usuario activo que realiza el alquiler.
        private readonly Usuarios _usuarioActivo;

        // ─────────────────────────────────────────────────────────────────
        // Constructor
        // ─────────────────────────────────────────────────────────────────

        // Constructor que recibe el vehículo, el usuario activo y el facade de alquileres.
        public FrmRegistrarAlquiler(Vehiculos vehiculo, Usuarios usuarioActivo,
                                    AlquilerFacade alquilerFacade)
        {
            InitializeComponent();
            _vehiculo = vehiculo;
            _usuarioActivo = usuarioActivo;
            _alquilerFacade = alquilerFacade;
        }

        // ─────────────────────────────────────────────────────────────────
        // Eventos del formulario
        // ─────────────────────────────────────────────────────────────────

        // Configura el formulario al cargar, mostrando los datos del vehículo
        private void FrmRegistrarAlquiler_Load(object sender, EventArgs e)
        {
            // Carga los datos del vehiculo en los labels
            lblPlacaValor.Text = _vehiculo.Placa;
            lblMarcaModeloValor.Text = $"{_vehiculo.Marca} {_vehiculo.Modelo}";
            lblTipoValor.Text = _vehiculo.TiposVehiculo.NombreTipo;

            // Configura las fechas por defecto
            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today.AddDays(1);

            // Carga las tarifas del vehiculo en el ComboBox
            CargarTarifas();

            // Calcula el costo inicial
            CalcularCosto();
        }

        // ─────────────────────────────────────────────────────────────────
        // Eventos de los controles
        // ─────────────────────────────────────────────────────────────────

        // Evento del botón Confirmar para registrar el alquiler
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (!ValidarFechas()) return;

            if (cmbTarifa.SelectedValue == null) return;

            int tarifaId = ((TarifaComboItem)cmbTarifa.SelectedItem).TarifaId;

            var confirmacion = MessageBox.Show(
                $"Vehiculo: {_vehiculo.Marca} {_vehiculo.Modelo}\n" +
                $"Tarifa:   {cmbTarifa.Text}\n" +
                $"Inicio:   {dtpFechaInicio.Value.ToShortDateString()}\n" +
                $"Fin:      {dtpFechaFin.Value.ToShortDateString()}\n" +
                $"Costo:    {lblCostoValor.Text}\n\n" +
                $"¿Confirmar el alquiler?",
                "Confirmar Alquiler",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes) return;

            _alquilerFacade.RegistrarAlquiler(
                _usuarioActivo.UsuarioId,
                _vehiculo.VehiculoId,
                tarifaId,
                dtpFechaInicio.Value,
                dtpFechaFin.Value
            );

            MessageBox.Show(
                "Alquiler registrado correctamente.\n" +
                "Su solicitud esta pendiente de aprobacion.",
                "Exito",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            this.Close();
        }

        // Evento del botón Cancelar para cerrar el formulario sin registrar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Eventos para recalcular el costo cada vez que cambian las fechas o la tarifa
        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            CalcularCosto();
        }

        // Evento para recalcular el costo cada vez que cambian las fechas o la tarifa
        private void dtpFechaFin_ValueChanged(object sender, EventArgs e)
        {
            CalcularCosto();
        }

        // Evento para recalcular el costo cada vez que cambian las fechas o la tarifa
        private void cmbTarifa_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcularCosto();
        }

        // ─────────────────────────────────────────────────────────────────
        // Métodos privados
        // ─────────────────────────────────────────────────────────────────

        // Carga las tarifas disponibles del vehiculo en el ComboBox.
        private void CargarTarifas()
        {
            var tarifas = _alquilerFacade.ObtenerTarifasPorVehiculo(_vehiculo.VehiculoId);

            var tarifasProyectadas = tarifas.Select(t => new TarifaComboItem
            {
                TarifaId = t.TarifaId,
                Descripcion = $"{t.TiposTarifa.NombreTarifa} - ${t.Monto:F2}"
            }).ToList();

            cmbTarifa.DataSource = tarifasProyectadas;
            cmbTarifa.DisplayMember = "Descripcion";
            cmbTarifa.ValueMember = "TarifaId";
        }

        // Calcula el costo estimado del alquiler según la tarifa y las fechas.
        private void CalcularCosto()
        {
            if (cmbTarifa.SelectedValue == null) return;

            int tarifaId = ((TarifaComboItem)cmbTarifa.SelectedItem).TarifaId;
            var tarifas = _alquilerFacade.ObtenerTarifasPorVehiculo(_vehiculo.VehiculoId);
            var tarifa = tarifas.FirstOrDefault(t => t.TarifaId == tarifaId);

            if (tarifa == null) return;

            int dias = (dtpFechaFin.Value - dtpFechaInicio.Value).Days;

            if (dias <= 0)
            {
                lblCostoValor.Text = "$0.00";
                return;
            }

            decimal costo = tarifa.Monto * dias;
            lblCostoValor.Text = $"${costo:F2}";
        }

        // Valida que las fechas sean correctas.
        private bool ValidarFechas()
        {
            if (dtpFechaInicio.Value.Date < DateTime.Today)
            {
                MessageBox.Show(
                    "La fecha de inicio no puede ser anterior a hoy.",
                    "Validacion",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (dtpFechaFin.Value.Date <= dtpFechaInicio.Value.Date)
            {
                MessageBox.Show(
                    "La fecha fin debe ser posterior a la fecha de inicio.",
                    "Validacion",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        
    }
}
