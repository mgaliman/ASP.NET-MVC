using System;
using System.ComponentModel.DataAnnotations;

namespace MyProject.DTO
{
    public class ProductDTO
    {
        public int IDProizvod { get; set; }

        [Required(ErrorMessage = "Name required!")]
        public string Naziv { get; set; }

        [Required(ErrorMessage = "Product number required!")]
        public string BrojProizvoda { get; set; }

        [Required(ErrorMessage = "Color required!")]
        public string Boja { get; set; }

        [Required(ErrorMessage = "Minimum quantity required!")]
        public short MinimalnaKolicinaNaSkladistu { get; set; }

        [Required(ErrorMessage = "Price without PDV required!")]
        public decimal CijenaBezPDV { get; set; }

        [Required(ErrorMessage = "Subcategory required!")]
        [Display(Name = "Subcategory")]
        public Nullable<int> PotkategorijaID { get; set; }
    }
}