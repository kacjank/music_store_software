using System.ComponentModel.DataAnnotations;

namespace Sklep_muzyczny.Models
{
    public class Producent
    {
        [Display(Name = "Id")]public int ProducentId { get; set; }
        public string Nazwa { get;set; }
        public string Kraj { get; set; }
        [Display(Name = "Data założenia"), DataType(DataType.Date)]
        public DateTime RokZalozenia { get;set; }
        public ICollection<Produkt>? Produkty { get; set; }
    }
}
