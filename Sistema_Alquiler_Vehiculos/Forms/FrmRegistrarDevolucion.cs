// ─────────────────────────────────────────────────────────────────────────────
// Archivo  : FrmRegistrarDevolucion.cs
// Capa     : Forms (Presentación)
// Propósito: Formulario modal para registrar cómo el cliente entrega el vehículo.
// ─────────────────────────────────────────────────────────────────────────────

using Sistema_Alquiler_Vehiculos.BLL;
using Sistema_Alquiler_Vehiculos.DAL;
using System;
using System.Windows.Forms;

namespace Sistema_Alquiler_Vehiculos.Forms
{
    public partial class FrmRegistrarDevolucion : Form
    {
        // ─────────────────────────────────────────────────────────────────
        // Atributos
        // ─────────────────────────────────────────────────────────────────

        // Almacena el alquiler activo que se está devolviendo
        private readonly Alquileres _alquilerActivo;

        // Facade para comunicarse con la base de datos de alquileres
        private readonly AlquilerFacade _alquilerFacade;
        public FrmRegistrarDevolucion(Alquileres alquilerActivo, AlquilerFacade alquilerFacade)
        {
            InitializeComponent();
            _alquilerActivo = alquilerActivo;
            _alquilerFacade = alquilerFacade;
        }

        // ─────────────────────────────────────────────────────────────────
        // Eventos
        // ─────────────────────────────────────────────────────────────────


        // Evento que se dispara al cambiar el estado del checkbox de daños
        private void chkDanios_CheckedChanged(object sender, EventArgs e)
        {
            // Si el check está marcado, activa el textbox. Si no, lo bloquea y lo vuelve a 0.
            if (chkDanios.Checked)
            {
                txtCostoDanios.Enabled = true;
                txtCostoDanios.Focus(); // Pone el cursor ahí para que escriba de una vez
            }
            else
            {
                txtCostoDanios.Enabled = false;
                txtCostoDanios.Text = "0.00";
            }
        }

        private void FrmRegistrarDevolucion_Load(object sender, EventArgs e)
        {
            // Carga los datos de solo lectura
            txtCliente.Text = $"{_alquilerActivo.Usuarios.Nombre} {_alquilerActivo.Usuarios.Apellido}";
            txtVehiculo.Text = $"{_alquilerActivo.Vehiculos.Marca} {_alquilerActivo.Vehiculos.Modelo} ({_alquilerActivo.Vehiculos.Placa})";
            txtFechaPactada.Text = _alquilerActivo.FechaFinPactada.ToShortDateString();

            // Configura la fecha de entrega por defecto al día de hoy
            dtpFechaDevolucion.Value = DateTime.Today;
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            // Validación de seguridad por si ponen letras en el costo de daños
            decimal costoDanios = 0;
            if (chkDanios.Checked)
            {
                if (!decimal.TryParse(txtCostoDanios.Text, out costoDanios) || costoDanios < 0)
                {
                    MessageBox.Show("Por favor, ingresa un monto válido para los daños.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCostoDanios.Focus();
                    return;
                }
            }

            // Confirmación final
            var confirmacion = MessageBox.Show(
                "¿Estás seguro de registrar la devolución? Esto generará el cobro final y liberará el vehículo.",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes) return;

            // Procesar en la base de datos
            _alquilerFacade.RegistrarDevolucion(
                _alquilerActivo.AlquilerId,
                dtpFechaDevolucion.Value,
                chkDanios.Checked,
                costoDanios);

            MessageBox.Show("Devolución procesada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close(); // Cierra esta ventanita
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
