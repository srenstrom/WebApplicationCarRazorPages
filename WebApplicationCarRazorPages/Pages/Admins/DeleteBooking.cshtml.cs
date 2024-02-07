using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplicationCarRazorPages.Data;

namespace WebApplicationCarRazorPages.Pages.Admins
{
    public class DeleteBookingModel : PageModel
    {
        private readonly IAdmin adminRep;

        public DeleteBookingModel(IAdmin adminRep)
        {
            this.adminRep = adminRep;
        }

        [BindProperty]
      public Booking Booking { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            
            var booking = adminRep.GetByBookingId(id);

            if (booking.EndDate < DateTime.Today)

            {
                TempData["ErrorMessage"] = "Du kan inte radera en bokning vars datum har passerat.";
                return RedirectToPage("ViewBookings");
            }
            if (booking == null)
            {
                return NotFound();
            }
            else
            {
                Booking = booking;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var booking = adminRep.GetByBookingId(id);

            if (booking != null)
            {
                Booking = booking;
                await adminRep.DeleteBooking(booking);
            }

            return RedirectToPage("./StartIndex");
        }
    }
}