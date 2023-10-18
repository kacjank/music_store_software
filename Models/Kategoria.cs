using System.ComponentModel.DataAnnotations;

namespace Sklep_muzyczny.Models
{
    public class Kategoria
    {
        [Display(Name = "Id")] public int KategoriaId { get; set; }
        public string Nazwa { get; set; }
        public ICollection<Podkategoria>? Podkategorie { get; set; }
        public ICollection<Produkt>? Produkty { get; set; }
    }
}
