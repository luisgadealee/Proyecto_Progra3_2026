// ─────────────────────────────────────────────────────────────────────────────
// Archivo  : FrmInicioSesion.cs
// Capa     : Forms (Presentación)
// Propósito: Formulario de inicio de sesión del sistema.
// Patrón   : 
// ─────────────────────────────────────────────────────────────────────────────

using System;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace Sistema_Alquiler_Vehiculos.Forms
{
    /// <summary>
    /// Formulario de inicio de sesión.
    /// Permite al usuario ingresar sus credenciales para acceder al sistema.
    /// </summary>
    public partial class FrmInicioSesion : Form
    {
        // ─────────────────────────────────────────────────────────────────────
        // Constructor
        // ─────────────────────────────────────────────────────────────────────

        /// <summary>
        /// Inicializa los componentes visuales del formulario.
        /// </summary>
        public FrmInicioSesion()
        {
            InitializeComponent();
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
            /// <summary>
            ///## ¿Por qué funciona así?
            ///Porque `Enabled` es una propiedad de tipo `bool`, es decir solo acepta `true` o `false`. 
            ///Y `usuarioTieneTexto && contraseniaTieneTexto` también devuelve `true` o `false`. Entonces puedes asignar directamente el resultado de la expresión a la propiedad.
            ///"No compares un booleano contra true o false, ya ES un booleano."
            /// <summary>
            btnConectar.Enabled = usuarioTieneTexto && contraseniaTieneTexto;
        }
    }
}
