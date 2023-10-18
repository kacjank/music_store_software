using System.ComponentModel.DataAnnotations;

namespace Sklep_muzyczny.Models
{
    public class Podkategoria
    {
        [Display(Name = "Kategoria")] public int? KategoriaId { get; set; }
        [Display(Name = "Id"), Key] public int PodkategoriaId { get; set; }
        public string Nazwa { get; set; }
        public Kategoria? Kategoria { get; set; }
        public ICollection<Produkt>? Produkty { get; set; }
    }
}
