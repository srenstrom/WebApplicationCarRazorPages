using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplicationCarRazorPages.Data;

namespace WebApplicationCarRazorPages.Pages.Bookings
{
    public class CreateBookingModel : PageModel
    {
        private readonly ICustomer customerRep;

        public CreateBookingModel(ICustomer customerRep)
        {
            this.customerRep = customerRep;
        }
        [BindProperty]
        public Booking Booking { get; set; } = new Booking();

        public Customer Customer { get; set; } = default!;
        public IActionResult OnGet(int? id)
        {
            var loggedInCustomer = customerRep.GetByCustomerId(id); //hämtar customer med hjälp av ID som den fick av login customer
            
            Booking.Customer = loggedInCustomer;
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(Booking booking)
        {
            
            var customer = customerRep.GetByCustomerId(booking.Customer.CustomerId);
            var car = customerRep.GetById(booking.Car.Id);
            booking.Customer = customer;
            booking.Car = car;
            if (car == null)
            {
                TempData["ErrorMessage"] = "Angivet bil-id finns inte i lagret, kontrollera att du anger ett giltigt bil-id som finns under \"Våra bilar\" och försök igen";
                return RedirectToPage("LoginIndex", booking.Customer );
            }
            if (booking == null)
            {
                return Page();
            }

            booking = customerRep.CreateBooking(booking);

            return RedirectToPage("./CustomerConfirmedBooking", customer);
            
        }
    }
}
