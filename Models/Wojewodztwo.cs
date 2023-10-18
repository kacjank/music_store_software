using System.ComponentModel.DataAnnotations;

namespace Sklep_muzyczny.Models
{
    public class Wojewodztwo
    {
        [Display(Name = "Id")] public int WojewodztwoId { get; set; }
        public string Nazwa { get;set; }
        public ICollection<Klient>? Klienci { get; set; }
    }
}
