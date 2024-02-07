using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationCarRazorPages.Data
{
    [Table ("Car")]
    public class Car
    {
        [Display(Name = "Bil-id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Obligatoriskt fält.")]
        [Display(Name = "Tillverkare")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Obligatoriskt fält.")]
        [Display(Name = "Modell")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Obligatoriskt fält.")]
        [Display(Name = "Pris/dygn")]
        public float PricePerDay { get; set; }

        [Required(ErrorMessage = "Obligatoriskt fält.")]
        [Display(Name = "Bildlänk")]
        public string PictureLink { get; set; }


    }
}
