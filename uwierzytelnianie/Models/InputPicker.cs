using System.ComponentModel.DataAnnotations;

namespace uwierzytelnianie.Models
{
    public class InputPicker
    {


        [Display(Name = "Imię")]
        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "Maksymalnie 100 znaków")]
        public string? name { get; set; }

        [Display(Name = "Rok urodzenia")]
        [Required]
        [Range(1899, 2022, ErrorMessage = "Oczekiwana wartość {0} z zakresu {1} i {2}.")]
        public int? date { get; set; }

        public string IsLeapYear()
        {
            if (this.date == null || ((this.date % 4 == 0 && this.date % 100 != 0) || this.date % 400 == 0))
                return string.Empty;
            else
                return "nie";
        }
    }
}
