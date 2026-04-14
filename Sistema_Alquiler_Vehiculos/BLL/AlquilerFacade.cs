// ─────────────────────────────────────────────────────────────────────────────
// Archivo  : AlquilerFacade.cs
// Capa     : BLL (Business Logic Layer)
// Propósito: Intermediario entre los formularios y la base de datos
//            para todo lo relacionado con alquileres.
// Patrón   : Facade
// ─────────────────────────────────────────────────────────────────────────────

using Sistema_Alquiler_Vehiculos.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sistema_Alquiler_Vehiculos.BLL
{

    // Facade de alquileres. Los formularios solo hablan con esta clase.
    public class AlquilerFacade
    {
        // ─────────────────────────────────────────────────────────────────
        // Atributos
        // ─────────────────────────────────────────────────────────────────

        // Conexión a la base de datos a través de Entity Framework.
        private readonly AlquilerVehiculosEntities _db;

        // ─────────────────────────────────────────────────────────────────
        // Constructor
        // ─────────────────────────────────────────────────────────────────

        // Constructor que inicializa el contexto de Entity Framework.
        public AlquilerFacade()
        {
            _db = new AlquilerVehiculosEntities();
        }

        // ─────────────────────────────────────────────────────────────────
        // Métodos públicos
        // ─────────────────────────────────────────────────────────────────

        // Obtiene todos los alquileres de un cliente específico.
        public List<Alquileres> ObtenerPorCliente(int usuarioId)
        {
            return _db.Alquileres
                      .Where(a => a.UsuarioId == usuarioId)
                      .ToList();
        }

        // Obtiene los alquileres activos de un cliente.
        // Un alquiler se considera activo si su EstadoId es 2 (Alquilado).
        public List<Alquileres> ObtenerActivosPorCliente(int usuarioId)
        {
            return _db.Alquileres
                      .Where(a => a.UsuarioId == usuarioId && a.EstadoId == 2)
                      .ToList();
        }

        // Registra un nuevo alquiler en la base de datos.
        // El alquiler se crea con EstadoId = 1 (Reservado) y sin daños ni multas.
        public void RegistrarAlquiler(int usuarioId, int vehiculoId, int tarifaId,
                                       DateTime fechaInicio, DateTime fechaFinPactada)
        {
            var alquiler = new Alquileres
            {
                UsuarioId = usuarioId,
                VehiculoId = vehiculoId,
                TarifaId = tarifaId,
                EstadoId = 1,
                FechaInicio = fechaInicio,
                FechaFinPactada = fechaFinPactada,
                TieneDanios = false,
                CostoDanios = 0,
                MultaRetraso = 0
            };

            _db.Alquileres.Add(alquiler);
            _db.SaveChanges();
        }

        // Obtiene las tarifas disponibles para un vehículo específico.
        // Esto es útil para mostrar las opciones de tarifas al cliente al momento de reservar.
        public List<Tarifas> ObtenerTarifasPorVehiculo(int vehiculoId)
        {
            return _db.Tarifas
                      .Where(t => t.VehiculoId == vehiculoId)
                      .ToList();
        }
    }
}