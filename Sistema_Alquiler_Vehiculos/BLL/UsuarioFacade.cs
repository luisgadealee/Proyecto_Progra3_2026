// ─────────────────────────────────────────────────────────────────────────────
// Archivo  : UsuarioFacade.cs
// Capa     : BLL (Business Logic Layer)
// Propósito: Intermediario entre los formularios y la base de datos para todo lo relacionado con usuarios.
// Patrón   : Facade — oculta la complejidad de EF a los formularios.
// ─────────────────────────────────────────────────────────────────────────────

using Sistema_Alquiler_Vehiculos.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

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

        // Obtiene el teléfono principal (el primero) de un usuario.
        public string ObtenerTelefonoPrincipal(int usuarioId)
        {
            var telefono = _db.Telefonos.FirstOrDefault(t => t.UsuarioId == usuarioId);
            return telefono != null ? telefono.Numero : "";
        }

        // Actualiza los datos personales del usuario.
        // Si el usuario escribe una nueva contraseña, la actualiza.
        public void ActualizarPerfil(int usuarioId, string nombre, string apellido,
                                     string email, string nuevaClave, string telefono)
        {
            // 1. Actualizar datos en la tabla Usuarios
            var usuario = _db.Usuarios.Find(usuarioId);
            if (usuario == null) return;

            usuario.Nombre = nombre;
            usuario.Apellido = apellido;
            usuario.Email = email;

            if (!string.IsNullOrWhiteSpace(nuevaClave))
            {
                usuario.Contrasenia = nuevaClave;
            }

            // 2. Actualizar o crear Teléfono en la tabla Telefonos
            var telBD = _db.Telefonos.FirstOrDefault(t => t.UsuarioId == usuarioId);

            if (telBD != null)
            {
                telBD.Numero = telefono; // Actualiza el existente
            }
            else if (!string.IsNullOrWhiteSpace(telefono))
            {
                // Si no tenía teléfono y escribió uno, lo inserta
                _db.Telefonos.Add(new Telefonos
                {
                    UsuarioId = usuarioId,
                    Numero = telefono
                });
            }

            _db.SaveChanges();
        }

        // Obtiene la lista completa de clientes (RolId = 1) para la grilla del admin
        public List<Usuarios> ObtenerTodosLosClientes()
        {
            return _db.Usuarios.Where(u => u.RolId == 1).ToList();
        }

        // Obtiene el teléfono de un usuario (para mostrarlo en la edición)
        public string ObtenerTelefono(int usuarioId)
        {
            var tel = _db.Telefonos.FirstOrDefault(t => t.UsuarioId == usuarioId);
            return tel != null ? tel.Numero : "";
        }

        // Guarda o actualiza un cliente y su teléfono
        public void GuardarCliente(Usuarios cliente, string numeroTelefono)
        {
            if (cliente.UsuarioId == 0) // Es NUEVO
            {
                // ─────────────────────────────────────────────────────────────
                // CAMBIO: Solo ponemos Rol 1 si el objeto NO trae ya un Rol asignado.
                // Si viene del formulario de empleados, ya traerá 2, 3 o 4.
                // ─────────────────────────────────────────────────────────────
                if (cliente.RolId == 0)
                {
                    cliente.RolId = 1;
                }

                cliente.FechaRegistro = DateTime.Now;
                cliente.Activo = true;
                _db.Usuarios.Add(cliente);
                _db.SaveChanges();

                _db.Telefonos.Add(new Telefonos { UsuarioId = cliente.UsuarioId, Numero = numeroTelefono });
            }
            else // Es EDICIÓN
            {
                var dbUser = _db.Usuarios.Find(cliente.UsuarioId);
                if (dbUser != null)
                {
                    dbUser.Nombre = cliente.Nombre;
                    dbUser.Apellido = cliente.Apellido;
                    dbUser.Email = cliente.Email;
                    dbUser.Cedula = cliente.Cedula;
                    // IMPORTANTE: También debemos actualizar el Rol por si lo cambiaron
                    dbUser.RolId = cliente.RolId;

                    var dbTel = _db.Telefonos.FirstOrDefault(t => t.UsuarioId == dbUser.UsuarioId);
                    if (dbTel != null) dbTel.Numero = numeroTelefono;
                    else _db.Telefonos.Add(new Telefonos { UsuarioId = dbUser.UsuarioId, Numero = numeroTelefono });
                }
            }
            _db.SaveChanges();
        }

        // Busca un usuario específico por su llave primaria (ID).
        // Se utiliza para cargar los datos en el formulario antes de editar.
        public Usuarios ObtenerPorId(int usuarioId)
        {
            // .Find busca directamente en el set de Usuarios por su ID
            return _db.Usuarios.Find(usuarioId);
        }

        // Obtiene todos los usuarios que NO son clientes (Vendedores, Admins, SuperUsers)
        public List<Usuarios> ObtenerTodosLosEmpleados()
        {
            return _db.Usuarios.Where(u => u.RolId > 1).ToList();
        }

        // Obtiene la lista de roles disponibles para el ComboBox de empleados
        public List<Roles> ObtenerRolesEmpleados()
        {
            // Solo roles administrativos (2, 3, 4)
            return _db.Roles.Where(r => r.RolId > 1).ToList();
        }
    }
}