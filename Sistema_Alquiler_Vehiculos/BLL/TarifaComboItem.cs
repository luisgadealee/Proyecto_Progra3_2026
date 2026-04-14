// ─────────────────────────────────────────────────────────────────────────────
// Archivo  : TarifaComboItem.cs
// Capa     : BLL (Business Logic Layer)
// Propósito: Modelo simple para mostrar tarifas en un ComboBox.
//            Evita usar tipos anonimos que causan problemas con SelectedValue.
// ─────────────────────────────────────────────────────────────────────────────

namespace Sistema_Alquiler_Vehiculos.BLL
{

    // Contenedor de datos para mostrar tarifas en un ComboBox.
    public class TarifaComboItem
    {
        //ID de la tarifa en la base de datos.
        public int TarifaId { get; set; }

        //Texto que se muestra en el ComboBox.
        public string Descripcion { get; set; }
    }
}