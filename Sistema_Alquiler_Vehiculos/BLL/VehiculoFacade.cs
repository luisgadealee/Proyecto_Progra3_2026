// ─────────────────────────────────────────────────────────────────────────────
// Archivo  : VehiculoFacade.cs
// Capa     : BLL (Business Logic Layer)
// Propósito: Intermediario entre los formularios y la base de datos
//            para todo lo relacionado con vehículos.
// Patrón   : Facade
// ─────────────────────────────────────────────────────────────────────────────

using System.Collections.Generic;
using System.Linq;
using Sistema_Alquiler_Vehiculos.DAL;

namespace Sistema_Alquiler_Vehiculos.BLL
{

    // Facade de vehículos. Los formularios solo hablan con esta clase.
    public class VehiculoFacade
    {
        // ─────────────────────────────────────────────────────────────────
        // Atributos
        // ─────────────────────────────────────────────────────────────────

        /// <summary>
        /// Contexto de Entity Framework.
        /// </summary>
        private readonly AlquilerVehiculosEntities _db;

        // ─────────────────────────────────────────────────────────────────
        // Constructor
        // ─────────────────────────────────────────────────────────────────

        public VehiculoFacade()
        {
            _db = new AlquilerVehiculosEntities();
        }

        // ─────────────────────────────────────────────────────────────────
        // Métodos públicos
        // ─────────────────────────────────────────────────────────────────

        /// <summary>
        /// Obtiene todos los vehículos disponibles para alquilar.
        /// </summary>
        /// <returns>Lista de vehículos con EstadoId = 1 (Disponible)</returns>
        public List<Vehiculos> ObtenerDisponibles()
        {
            return _db.Vehiculos
                      .Where(v => v.EstadoId == 1 && v.Activo == true)
                      .ToList();
        }

        /// <summary>
        /// Obtiene todos los vehículos disponibles filtrados por marca.
        /// </summary>
        /// <param name="marca">Marca a filtrar</param>
        /// <returns>Lista de vehículos disponibles de esa marca</returns>
        public List<Vehiculos> ObtenerDisponiblesPorMarca(string marca)
        {
            return _db.Vehiculos
                      .Where(v => v.EstadoId == 1 && v.Activo == true
                               && v.Marca == marca)
                      .ToList();
        }

        /// <summary>
        /// Obtiene todas las marcas distintas de vehículos disponibles.
        /// Se usa para llenar el ComboBox de filtro.
        /// </summary>
        /// <returns>Lista de marcas únicas</returns>
        public List<string> ObtenerMarcasDisponibles()
        {
            return _db.Vehiculos
                      .Where(v => v.EstadoId == 1 && v.Activo == true)
                      .Select(v => v.Marca)
                      .Distinct()
                      .ToList();
        }
    }
}