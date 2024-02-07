using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplicationCarRazorPages.Data;

namespace WebApplicationCarRazorPages.Pages.Admins
{
    public class CreateCustomerModel : PageModel
    {
        private readonly IAdmin adminRep;

        public CreateCustomerModel(IAdmin adminRep)
        {
            this.adminRep = adminRep;
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

            adminRep.CreateCustomer(customer);

            return RedirectToPage("./ViewCustomers");
        }


    }
}