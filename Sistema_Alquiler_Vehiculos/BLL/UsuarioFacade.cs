// ─────────────────────────────────────────────────────────────────────────────
// Archivo  : UsuarioFacade.cs
// Capa     : BLL (Business Logic Layer)
// Propósito: Intermediario entre los formularios y la base de datos para todo lo relacionado con usuarios.
// Patrón   : Facade — oculta la complejidad de EF a los formularios.
// ─────────────────────────────────────────────────────────────────────────────

using System.Linq;
using Sistema_Alquiler_Vehiculos.DAL;

namespace Sistema_Alquiler_Vehiculos.BLL
{
    /// <summary>
    /// Facade de usuarios. Los formularios solo hablan con esta clase,
    /// nunca acceden directamente a Entity Framework ni a la base de datos.
    /// </summary>
    public class UsuarioFacade
    {
        // El DbContext que EF generó automáticamente.
        // Esta es la única instancia de AlquilerVehiculosEntities que se usa en toda la aplicación.
        // Es la puerta de entrada a la base de datos, y se encarga de administrar las conexiones, las consultas y los cambios.
        private readonly AlquilerVehiculosEntities _db;

        // ─────────────────────────────────────────────────────────────────
        // Constructor
        // ─────────────────────────────────────────────────────────────────

        /// <summary>
        /// Inicializa el contexto de Entity Framework.
        /// </summary>
        public UsuarioFacade()
        {
            _db = new AlquilerVehiculosEntities();
        }

        // ─────────────────────────────────────────────────────────────────
        // Métodos públicos
        // ─────────────────────────────────────────────────────────────────

        /// <summary>
        /// Valida las credenciales de un usuario contra la base de datos.
        /// Verifica que exista, que la contraseña sea correcta y que esté activo.
        /// </summary>
        /// <param name="nombreUsuario">Nombre de usuario ingresado en el form</param>
        /// <param name="contrasenia">Contraseña ingresada en el form</param>
        /// <returns>
        /// El objeto Usuarios si las credenciales son correctas.
        /// Null si el usuario no existe, la contraseña es incorrecta o está inactivo.
        /// </returns>
        public Usuarios ValidarCredenciales(string nombreUsuario, string contrasenia)
        {
            // Busca en la BD un usuario que coincida con ambos campos
            // y que además esté activo en el sistema.
            // FirstOrDefault devuelve el primero que encuentre o null si no hay.
            return _db.Usuarios.FirstOrDefault(u =>
                u.NombreUsuario == nombreUsuario &&
                u.Contrasenia == contrasenia &&
                u.Activo == true);
        }
    }
}