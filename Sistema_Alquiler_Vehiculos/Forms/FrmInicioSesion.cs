// ─────────────────────────────────────────────────────────────────────────────
// Archivo  : FrmInicioSesion.cs
// Capa     : Forms (Presentación)
// Propósito: Formulario de inicio de sesión del sistema.
// Patrón   : 
// ─────────────────────────────────────────────────────────────────────────────

using Sistema_Alquiler_Vehiculos.BLL;
using Sistema_Alquiler_Vehiculos.DAL;
using System;
using System.Linq.Expressions;
using System.Windows.Forms;
using Sistema_Alquiler_Vehiculos.Forms;

namespace Sistema_Alquiler_Vehiculos.Forms
{
    /// <summary>
    /// Formulario de inicio de sesión.
    /// Permite al usuario ingresar sus credenciales para acceder al sistema.
    /// </summary>
    public partial class FrmInicioSesion : Form
    {

        // ─────────────────────────────────────────────────────────────────
        // Atributos
        // ─────────────────────────────────────────────────────────────────

        /// <summary>
        /// Facade de usuarios. Es el único punto de contacto
        /// entre este formulario y la base de datos.
        /// </summary>
        private readonly UsuarioFacade _usuarioFacade;

        // ─────────────────────────────────────────────────────────────────────
        // Constructor
        // ─────────────────────────────────────────────────────────────────────

        /// <summary>
        /// Inicializa los componentes visuales del formulario.
        /// </summary>
        public FrmInicioSesion()
        {
            InitializeComponent();
            _usuarioFacade = new UsuarioFacade();
        }

        // ─────────────────────────────────────────────────────────────────────
        // Eventos del formulario
        // ─────────────────────────────────────────────────────────────────────

        /// <summary>
        /// Se ejecuta cuando el formulario carga por primera vez.
        /// Configura el estado inicial de los controles.
        /// </summary>
        private void FrmInicioSesion_Load(object sender, EventArgs e)
        {
            // Oculta el texto de la contraseña por seguridad
            txtContrasenia.PasswordChar = '*';

            // El botón inicia deshabilitado porque los campos están vacíos
            btnConectar.Enabled = false;
        }

        // ─────────────────────────────────────────────────────────────────────
        // Eventos de los controles
        // ─────────────────────────────────────────────────────────────────────

        /// <summary>
        /// Se ejecuta cada vez que el usuario escribe en el campo Usuario.
        /// Verifica si el botón Conectar debe habilitarse.
        /// </summary>
        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            ValidarCampos();
        }

        /// <summary>
        /// Se ejecuta cada vez que el usuario escribe en el campo Contraseña.
        /// Verifica si el botón Conectar debe habilitarse.
        /// </summary>
        private void txtContrasenia_TextChanged(object sender, EventArgs e)
        {
            ValidarCampos();
        }


        // Valida las credenciales ingresadas y abre el formulario principal según el rol del usuario
        private void btnConectar_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txtUsuario.Text.Trim();
            string contrasenia = txtContrasenia.Text.Trim();

            Usuarios usuarioActivo = _usuarioFacade.ValidarCredenciales(
                                         nombreUsuario, contrasenia);

            if (usuarioActivo == null)
            {
                MessageBox.Show(
                    "Usuario o contraseña incorrectos o cuenta inactiva.",
                    "Acceso denegado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtContrasenia.Clear();
                txtUsuario.Focus();
                return;
            }

            // Abre el formulario principal según el rol del usuario
            Form frmPrincipal = null;

            switch (usuarioActivo.RolId)
            {
                case 1:
                    // 1 = Cliente (Tiene su propia pantalla independiente)
                    frmPrincipal = new FrmPrincipalCliente(usuarioActivo);
                    break;
                case 2:
                case 3:
                case 4:
                    // 2 = Vendedor, 3 = Admin, 4 = SuperUsuario
                    // Todos usan la MISMA pantalla administrativa.
                    // El evento "Load" de ese formulario se encargará de ocultar los botones.
                    frmPrincipal = new FrmPrincipalAdministrador(usuarioActivo);
                    break;
                default:
                    MessageBox.Show("El rol asignado no es válido para entrar al sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            if (frmPrincipal == null) return;

            // Oculta el login y abre el formulario principal
            this.Hide();
            frmPrincipal.ShowDialog();
            this.Close();
        }

        // ─────────────────────────────────────────────────────────────────────
        // Métodos privados
        // ─────────────────────────────────────────────────────────────────────

        /// <summary>
        /// Habilita o deshabilita el botón Conectar según si ambos campos
        /// tienen contenido. Ambos campos deben tener al menos 1 carácter.
        /// </summary>
        private void ValidarCampos()
        {
            // Trim() elimina espacios en blanco al inicio y al final,
            // evita que el usuario ponga solo espacios y pase la validación
            bool usuarioTieneTexto = txtUsuario.Text.Trim().Length > 0;
            bool contraseniaTieneTexto = txtContrasenia.Text.Trim().Length > 0;
            //Principio de clean code: if reducido a una sola línea con variables booleanas para mejorar legibilidad
            //## ¿Por qué funciona así?
            //Porque `Enabled` es una propiedad de tipo `bool`, es decir solo acepta `true` o `false`. 
            //Y `usuarioTieneTexto && contraseniaTieneTexto` también devuelve `true` o `false`. Entonces puedes asignar directamente el resultado de la expresión a la propiedad.
            //"No compares un booleano contra true o false, ya ES un booleano."
            btnConectar.Enabled = usuarioTieneTexto && contraseniaTieneTexto;
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            var frm = new FrmRegistro();
            frm.ShowDialog();
        }
    }
}
