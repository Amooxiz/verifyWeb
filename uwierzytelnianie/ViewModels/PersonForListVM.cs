using System.ComponentModel.DataAnnotations;

namespace uwierzytelnianie.ViewModels
{
    public class PersonForListVM
    {
        public int Id { get; set; }
        [Display(Name = "Imię i Nazwisko")]
        public string FullName { get; set; }
        [Display(Name="Data dołączenia")]
        public string JoinDate { get; set; }
        [Display(Name="Rok urodzenia")]
        public int Year { get; set; }
    }
}
