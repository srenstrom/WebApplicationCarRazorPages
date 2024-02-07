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
        //[Range(typeof(DateTime), "1900-01-01", "9999-12-31", ErrorMessage = "Startdatum kan tidigast vara från och med morgondagens datum")]
        [Display(Name = "Hyrdatum")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Vänligen ange hyrdatum")]
        //[Range(typeof(DateTime), "1900-01-01", "9999-12-31", ErrorMessage = "Slutdatum kan inte vara bakåt i tiden")]
        [Display(Name = "Returdatum")]
        public DateTime EndDate { get; set; }

        public Booking()
        {
            StartDate = new DateTime(DateTime.Now.Year, 1, 1); // Året kommer att sättas till det nuvarande året
            EndDate = new DateTime(DateTime.Now.Year, 1, 1);
        }
    }
}
