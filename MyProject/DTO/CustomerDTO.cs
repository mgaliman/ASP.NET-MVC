using System;
using System.ComponentModel.DataAnnotations;

namespace MyProject.DTO
{
    public class CustomerDTO
    {
        public int IDKupac { get; set; }

        [Required(ErrorMessage = "Name required!")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Lastname required!")]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "E-mail required!")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Insert valid E-mail address!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Insert phone number!")]
        public string Telefon { get; set; }

        [Required(ErrorMessage = "City required!")]
        [Display(Name = "City")]
        public Nullable<int> GradID { get; set; }
    }
}