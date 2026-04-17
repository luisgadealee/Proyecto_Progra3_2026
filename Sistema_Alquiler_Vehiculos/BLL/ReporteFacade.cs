// ─────────────────────────────────────────────────────────────────────────────
// Archivo  : ReporteFacade.cs
// Propósito: Motor de cálculos financieros para el Dashboard.
// ─────────────────────────────────────────────────────────────────────────────

using Sistema_Alquiler_Vehiculos.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Sistema_Alquiler_Vehiculos.BLL
{
    public class ReporteFacade
    {
        private readonly AlquilerVehiculosEntities _db = new AlquilerVehiculosEntities();

        // Obtiene la suma total de las tarifas base pactadas
        public decimal ObtenerTotalRentas()
        {
            // Se suma el (Monto de Tarifa * Dias) de todos los alquileres cerrados
            // Para simplificar, se calcula la diferencia entre Total y (Multas + Daños)
            var totalPagos = _db.Pagos.Sum(p => (decimal?)p.Monto) ?? 0;
            var totalMultas = _db.Alquileres.Sum(a => (decimal?)a.MultaRetraso) ?? 0;
            var totalDanios = _db.Alquileres.Sum(a => (decimal?)a.CostoDanios) ?? 0;

            return totalPagos - (totalMultas + totalDanios);
        }

        public decimal ObtenerTotalMultas()
        {
            return _db.Alquileres.Sum(a => (decimal?)a.MultaRetraso) ?? 0;
        }

        public decimal ObtenerTotalDanios()
        {
            return _db.Alquileres.Sum(a => (decimal?)a.CostoDanios) ?? 0;
        }

        public List<Pagos> ObtenerDetallePagos()
        {
            return _db.Pagos.Include(p => p.Alquileres.Usuarios).OrderByDescending(p => p.FechaPago).ToList();
        }
    }
}
