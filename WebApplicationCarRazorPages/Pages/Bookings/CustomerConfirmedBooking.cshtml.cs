using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationCarRazorPages.Data;

namespace WebApplicationCarRazorPages.Pages.Bookings
{
    public class CustomerConfirmedBookingModel : PageModel
    {
        private readonly ICustomer customerRep;

        public CustomerConfirmedBookingModel(ICustomer customerRep)
        {
            this.customerRep = customerRep;
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Customer customer)
        {
            
            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                Customer = customer;
               
            }
            return Page();
        }



        //        // To protect from overposting attacks, enable the specific properties you want to bind to.
        //        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(Customer customer)
        {
            
            if (customer != null)
            {
                return RedirectToPage("LoginIndex", customer);
            }
            return NotFound();

        }
    }
}
