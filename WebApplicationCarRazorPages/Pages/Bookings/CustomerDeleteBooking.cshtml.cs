using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplicationCarRazorPages.Data;

namespace WebApplicationCarRazorPages.Pages.Bookings
{
    public class CustomerDeleteBookingModel : PageModel
    {
        private readonly ICustomer customerRep;

        public CustomerDeleteBookingModel(ICustomer customerRep)
        {
            this.customerRep = customerRep;
        }

        [BindProperty]
      public Booking Booking { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var booking = customerRep.GetByBookingId(id);

            if (booking == null)
            {
                return NotFound();
            }

            if (booking.EndDate < DateTime.Today)

            {

                TempData["ErrorMessage"] = "Du kan inte radera en bokning vars datum har passerat.";
                return RedirectToPage("./CustomerViewBookings", new { id = booking.Customer.CustomerId });
                
            }
          
            
            {
                Booking = booking;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            
            var booking = customerRep.GetByBookingId(id);
            var customer = customerRep.GetByCustomerId(booking.Customer.CustomerId);
            if (booking != null)
            {
                Booking = booking;
                await customerRep.DeleteBooking(booking);
            }

            return RedirectToPage("./LoginIndex", customer );
        }
    }
}
