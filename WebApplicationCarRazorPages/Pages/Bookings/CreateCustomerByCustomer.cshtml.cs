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
    public class CreateCustomerByCustomerModel : PageModel
    {
        private readonly WebApplicationCarRazorPages.Data.WebApplicationCarRazorPagesContext _context;
        private readonly ICustomer customerRep;

        public CreateCustomerByCustomerModel(ICustomer customerRep)
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
        public async Task<IActionResult> OnPostAsync(Customer customer)
        {
            if (!ModelState.IsValid || customer == null)
            {
                return Page();
            }

            customerRep.CreateCustomer(customer);
            TempData["ConfirmingMessage"] = "Din användare är skapad! Nu kan du logga in.";

            return RedirectToPage("./LoginCustomer");
        }


    }
}
