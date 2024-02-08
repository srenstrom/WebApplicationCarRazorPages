using System.ComponentModel.DataAnnotations;

namespace WebApplicationCarRazorPages.Data
{
    public class Booking
    {
        [Display(Name = "BokningsId")]
        public int BookingId { get; set; }

        [Display(Name = "Kund")]
        public Customer Customer { get; set; }

        [Display(Name = "Bil")]
        public Car Car { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Vänligen ange hyrdatum")]
     
        [Display(Name = "Hyrdatum")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Vänligen ange hyrdatum")]
   
        [Display(Name = "Returdatum")]
        public DateTime EndDate { get; set; }

        public Booking()
        {
            StartDate = new DateTime(DateTime.Now.Year, 1, 1); // Year will be set to current year
            EndDate = new DateTime(DateTime.Now.Year, 1, 1);
        }
    }
}
