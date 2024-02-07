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
    public class LoginCustomerModel : PageModel
    {
        private readonly ICustomer customerRep;

        public LoginCustomerModel(ICustomer customerRep)
        {
            this.customerRep = customerRep;
        }

        public IActionResult OnGet()
        {
            
            return Page();
        }
        [BindProperty]
        public Customer Customer { get; set; } = default!;

     

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
           
            var customer = customerRep.CheckCustomerUser(Customer.Email, Customer.Password);

            if (customer == null)
            {
                TempData["ErrorMessage"] = "Felaktiga inloggningsuppgifter. Vänligen försök igen.";
                return Page();
            }
            

            return RedirectToPage("./LoginIndex", customer);
          
        }
    }
}
