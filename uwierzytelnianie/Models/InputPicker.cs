using System.ComponentModel.DataAnnotations;

namespace uwierzytelnianie.Models
{
    public class InputPicker
    {


        [Display(Name = "Imię")]
        [Required, MaxLength(100)]
        public string? name { get; set; }

        [Display(Name = "Rok urodzenia")]
        [Required, Range(1899, 2022, ErrorMessage = "Oczekiwana wartość {0} z zakresu {1} i {2}.")]
        public int? date { get; set; }
    }
}
