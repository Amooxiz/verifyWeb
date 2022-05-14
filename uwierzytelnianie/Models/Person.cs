using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace uwierzytelnianie.Models
{
    public class Person
    {
        public int Id { get; set; }

        public AppUser? AppUser { get; set; }

        [Display(Name = "Imię")]
        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "Maksymalnie 100 znaków")]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Display(Name = "Nazwisko")]
        [StringLength(maximumLength: 100, ErrorMessage = "Maksymalnie 100 znaków")]
        [Column(TypeName = "varchar(100)")]
        public string? Surname { get; set; }

        [Display(Name = "Rok urodzenia")]
        [Required]
        [Range(1899, 2022, ErrorMessage = "Oczekiwana wartość {0} z zakresu {1} i {2}.")]
        public int Year { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsLeap { get; set; }


        public bool IsLeapYear()
        {
            if (((this.Year % 4 == 0 && this.Year % 100 != 0) || this.Year % 400 == 0))
            {
                this.IsLeap = true;
                return true;
            }
            else
            {
                this.IsLeap = false;
                return false;
            }
        }
    }
}
