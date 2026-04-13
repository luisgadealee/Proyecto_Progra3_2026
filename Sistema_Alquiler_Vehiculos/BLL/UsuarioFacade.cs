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

        // Verifica si una cedula ya existe en la base de datos.
        // Se usa para evitar duplicados al registrar un nuevo usuario.
        public bool ExisteCedula(string cedula)
        {
            return _db.Usuarios.Any(u => u.Cedula == cedula);
        }

        // Verifica si un nombre de usuario ya existe en la base de datos.
        // Se usa para evitar duplicados al registrar un nuevo usuario.
        public bool ExisteNombreUsuario(string nombreUsuario)
        {
            return _db.Usuarios.Any(u => u.NombreUsuario == nombreUsuario);
        }

        //verifica si un email ya existe en la base de datos.
        // Se usa para evitar duplicados al registrar un nuevo usuario.
        public bool ExisteEmail(string email)
        {
            return _db.Usuarios.Any(u => u.Email == email);
        }

        // Registra un nuevo cliente en la base de datos.
        // Recibe todos los datos necesarios para crear un nuevo usuario con rol de cliente.
        // Además, si se proporcionan números de teléfono, los agrega a la tabla de teléfonos relacionada.
        // Este método es llamado desde el formulario de registro de clientes.
        public void RegistrarCliente(string nombre, string apellido, string cedula,
                                     string email, string nombreUsuario, string contrasenia,
                                     string telefono1, string telefono2)
        {
            // Crea el nuevo usuario con RolId = 1 (Cliente)
            var nuevoUsuario = new Usuarios
            {
                Nombre = nombre,
                Apellido = apellido,
                Cedula = cedula,
                Email = email,
                NombreUsuario = nombreUsuario,
                Contrasenia = contrasenia,
                RolId = 1,
                Activo = true,
                FechaRegistro = System.DateTime.Now
            };

            _db.Usuarios.Add(nuevoUsuario);
            _db.SaveChanges();

            // Agrega los telefonos si fueron proporcionados
            if (!string.IsNullOrWhiteSpace(telefono1))
            {
                _db.Telefonos.Add(new Telefonos
                {
                    UsuarioId = nuevoUsuario.UsuarioId,
                    Numero = telefono1.Trim()
                });
            }

            if (!string.IsNullOrWhiteSpace(telefono2))
            {
                _db.Telefonos.Add(new Telefonos
                {
                    UsuarioId = nuevoUsuario.UsuarioId,
                    Numero = telefono2.Trim()
                });
            }

            _db.SaveChanges();
        }
    }
}