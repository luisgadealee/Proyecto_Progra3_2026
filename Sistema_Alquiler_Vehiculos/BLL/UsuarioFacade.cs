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