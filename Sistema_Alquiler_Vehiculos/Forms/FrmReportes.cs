// ─────────────────────────────────────────────────────────────────────────────
// Archivo  : FrmReportes.cs
// Capa     : Forms (Presentación)
// Propósito: Dashboard financiero que muestra el rendimiento económico 
//            desglosado por rentas, multas y daños.
// ─────────────────────────────────────────────────────────────────────────────

using Sistema_Alquiler_Vehiculos.BLL;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Sistema_Alquiler_Vehiculos.Forms
{

    public partial class FrmReportes : Form
    {
        // ─────────────────────────────────────────────────────────────────
        // Atributos
        // ─────────────────────────────────────────────────────────────────
        private readonly ReporteFacade _reporteFacade;

        // ─────────────────────────────────────────────────────────────────
        // Constructor
        // ─────────────────────────────────────────────────────────────────
        public FrmReportes()
        {
            InitializeComponent();
            _reporteFacade = new ReporteFacade();
        }
        // ─────────────────────────────────────────────────────────────────
        // Eventos del Formulario
        // ─────────────────────────────────────────────────────────────────
        private void FrmReportes_Load(object sender, EventArgs e)
        {
            CargarDashboard();
            CargarDGV();
        }

        // ─────────────────────────────────────────────────────────────────
        // Métodos de Carga
        // ─────────────────────────────────────────────────────────────────

        private void CargarDashboard()
        {
            // Obtenemos los totales desde la Facade
            decimal renta = _reporteFacade.ObtenerTotalRentas();
            decimal multas = _reporteFacade.ObtenerTotalMultas();
            decimal danios = _reporteFacade.ObtenerTotalDanios();

            // Formateamos como moneda (C2 pone el símbolo de moneda local)
            lblTotalRenta.Text = renta.ToString("C2");
            lblTotalMulta.Text = multas.ToString("C2");
            lblTotalDanio.Text = danios.ToString("C2");
        }

        private void CargarDGV()
        {
            var pagos = _reporteFacade.ObtenerDetallePagos();

            // Proyección para mostrar una auditoría clara en la tabla
            dgvPagos.DataSource = pagos.Select(p => new
            {
                ID = p.PagoId,
                Cliente = p.Alquileres.Usuarios.Nombre + " " + p.Alquileres.Usuarios.Apellido,
                MontoTotal = p.Monto.ToString("C2"),
                p.FechaPago,
                Estado = p.EstadoPago
            }).ToList();

            dgvPagos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
