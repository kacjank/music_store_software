using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Sklep_muzyczny.Models
{
    public class Produkt
    {
        [Display(Name = "ID")] public int ProduktId { get; set; }
        [Display(Name = "Producent")] public int ProducentId { get; set; }
        [DisplayFormat(NullDisplayText = "-")] public string? Model { get; set; }
        [Display(Name = "Kategoria"), Required] public int KategoriaId { get; set; }
        [Display(Name = "Podkategoria"), DisplayFormat(NullDisplayText = "-")]
        public int? PodkategoriaId { get; set; }
        [Display(Name = "Data produkcji"), DataType(DataType.Date),
            DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataProdukcji { get; set; }
        [DataType(DataType.Currency)] public decimal Cena { get; set; }
        public Kategoria? Kategoria { get; set; }
        public Podkategoria? Podkategoria { get; set; }
        public Producent? Producent { get; set; }
    }
}
