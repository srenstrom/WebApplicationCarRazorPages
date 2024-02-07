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
    public class CustomerViewBookingsModel : PageModel
    {
        private readonly ICustomer customerRep;

        public CustomerViewBookingsModel(ICustomer customerRep)
        {
            this.customerRep = customerRep;
        }


        public IList<Booking> Booking { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var customer = customerRep.GetByCustomerId(id);
            var viewAllBookings = await customerRep.GetAllBookings();

            var customerBookingExists = viewAllBookings.Where(c => c.Customer.CustomerId == customer.CustomerId).ToList();

            if (customerBookingExists.Count == 0 || customerBookingExists == null)
            {
                TempData["ErrorMessage"] = "Du har inga bokningar.";
                return RedirectToPage("LoginIndex", customer);
            }
            if (customerBookingExists != null && customerBookingExists.Any())
            
            {
                Booking = customerBookingExists.ToList();

            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var loggedInCustomer = customerRep.GetByBookingId(id);
            var customer = customerRep.GetByCustomerId(loggedInCustomer.Customer.CustomerId);
            if (customer != null)
            {
                return RedirectToPage("LoginIndex", customer);
            }
            return NotFound();
        }
    }
}