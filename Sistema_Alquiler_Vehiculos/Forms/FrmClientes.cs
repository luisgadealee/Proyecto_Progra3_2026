// ─────────────────────────────────────────────────────────────────────────────
// Archivo  : FrmClientes.cs
// Capa     : Forms (Presentación)
// Propósito: Formulario CRUD para la gestión administrativa de clientes.
//            Permite el registro de nuevos usuarios y actualización de datos.
// ─────────────────────────────────────────────────────────────────────────────

using Sistema_Alquiler_Vehiculos.BLL;
using Sistema_Alquiler_Vehiculos.DAL;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Sistema_Alquiler_Vehiculos.Forms
{
    public partial class FrmClientes : Form
    {
        // ─────────────────────────────────────────────────────────────────
        // Atributos
        // ─────────────────────────────────────────────────────────────────

        // Intermediario para operaciones con la tabla de Usuarios y Telefonos
        private readonly UsuarioFacade _usuarioFacade;

        // ─────────────────────────────────────────────────────────────────
        // Constructor
        // ─────────────────────────────────────────────────────────────────
        public FrmClientes()
        {
            InitializeComponent();
            _usuarioFacade = new UsuarioFacade();
        }

        // ─────────────────────────────────────────────────────────────────
        // Eventos del formulario
        // ─────────────────────────────────────────────────────────────────
        private void FrmClientes_Load(object sender, EventArgs e)
        {
            ActualizarDGV();
            LimpiarFormulario();
        }

        // ─────────────────────────────────────────────────────────────────
        // Eventos de Control
        // ─────────────────────────────────────────────────────────────────
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificación de campos requeridos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtCedula.Text))
            {
                MessageBox.Show("Por favor complete el Nombre y la Cédula.", "Información faltante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idFinal = 0;

            // Si el label dice "0", es nuevo. Si no, limpiamos el texto para dejar solo el número.
            if (lblId.Text != "0")
            {
                // Reemplazamos el texto descriptivo por nada ("") para que quede solo el número
                string soloNumero = lblId.Text.Replace("Su número de ID es: ", "");
                idFinal = int.Parse(soloNumero);
            }

            // Mapeo de datos desde los controles de la interfaz
            var cliente = new Usuarios
            {
                UsuarioId = idFinal,
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                Cedula = txtCedula.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                NombreUsuario = txtUsuario.Text.Trim(),
                Contrasenia = txtPass.Text // Se procesará en la Facade si es nuevo
            };

            // Ejecución del guardado en la capa de negocio
            _usuarioFacade.GuardarCliente(cliente, txtTelefono.Text.Trim());

            MessageBox.Show("Registro procesado exitosamente.", "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ActualizarDGV();
            LimpiarFormulario();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignorar clics en el encabezado
            if (e.RowIndex < 0) return;

            // Obtener el identificador único de la fila
            int usuarioId = (int)dgvClientes.Rows[e.RowIndex].Cells["UsuarioId"].Value;

            // Recuperar el objeto completo desde la base de datos
            var cliente = _usuarioFacade.ObtenerPorId(usuarioId);

            if (cliente != null)
            {
                // Carga de datos en los campos de texto
                lblId.Text = $"Su número de ID es: {cliente.UsuarioId}";
                lblId.Visible = true; // Mostrar el ID para referencia
                txtNombre.Text = cliente.Nombre;
                txtApellido.Text = cliente.Apellido;
                txtCedula.Text = cliente.Cedula;
                txtEmail.Text = cliente.Email;
                txtUsuario.Text = cliente.NombreUsuario;

                // Carga del teléfono relacionado
                txtTelefono.Text = _usuarioFacade.ObtenerTelefono(usuarioId);

                // Aplicación de lógica de seguridad en edición
                txtUsuario.ReadOnly = true;
                txtPass.Enabled = false;

                btnGuardar.Text = "Actualizar Cliente";
            }
        }

        // ─────────────────────────────────────────────────────────────────
        // Métodos de Carga
        // ─────────────────────────────────────────────────────────────────

        // Refresca la información del DataGridView con la lista de clientes
        private void ActualizarDGV()
        {
            var listaClientes = _usuarioFacade.ObtenerTodosLosClientes();

            // Selección de columnas específicas para la vista del administrador
            dgvClientes.DataSource = listaClientes.Select(c => new {
                c.UsuarioId,
                c.Cedula,
                NombreCompleto = c.Nombre + " " + c.Apellido,
                c.Email,
                c.NombreUsuario
            }).ToList();

            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ─────────────────────────────────────────────────────────────────
        // Métodos de Utilidad
        // ─────────────────────────────────────────────────────────────────

        // Restablece el formulario a su estado inicial
        private void LimpiarFormulario()
        {
            lblId.Text = "0";
            txtNombre.Clear();
            txtApellido.Clear();
            txtCedula.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
            txtUsuario.Clear();
            txtPass.Clear();

            txtUsuario.ReadOnly = false;
            txtPass.Enabled = true;

            btnGuardar.Text = "Guardar Nuevo Cliente";
            txtNombre.Focus();
        }
    }
}
