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
    public class LoginIndexModel : PageModel
    {
        private readonly ICustomer customerRep;

        public LoginIndexModel(ICustomer customerRep)
        {
            this.customerRep = customerRep;
        }

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
    }
}
