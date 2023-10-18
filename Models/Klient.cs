using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sklep_muzyczny.Models
{
    //public enum Wojewodztwo
    //{
    //    [Display(Name = "dolnośląskie")] dolnoslaskie,
    //    [Display(Name = "kujawsko-pomorskie")] kujawskopomorskie,
    //    lubelskie,
    //    lubuskie,
    //    [Display(Name = "łódzkie")] lodzkie,
    //    [Display(Name = "małopolskie")] malopolskie,
    //    mazowieckie,
    //    opolskie,
    //    podkarpackie,
    //    podlaskie,
    //    pomorskie,
    //    [Display(Name = "śląskie")] slaskie,
    //    [Display(Name = "świętokrzyskie")] swietokrzyskie,
    //    [Display(Name = "marmińsko-mazurskie")] warminskomazurskie,
    //    wielkopolskie,
    //    zachodniopomorskie
    //}
    public class Klient
    {
        [Display(Name = "Id")] public int KlientId { get; set; }
        [Display(Name = "Imię"), StringLength(30)] public string Imie { get; set; }
        [StringLength(60), Required] public string Nazwisko { get; set; }
        [Display(Name ="E-mail"), DataType(DataType.EmailAddress)] public string Email { get; set; }
        [Display(Name = "Województwo")] public string WojewodztwoId { get; set; }
        public string Miasto { get; set; }
        public string Adres { get; set; }
        [Display(Name = "Data rejestracji"),
            DataType(DataType.Date),
            DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",ApplyFormatInEditMode = true)]
        public DateTime DataRejestracji { get; set; }
        public Wojewodztwo? Wojewodztwo { get; set; }
    }
}
