using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationCarRazorPages.Data;

namespace WebApplicationCarRazorPages.Pages.Admins
{
    public class EditCustomerModel : PageModel
    {
        private readonly IAdmin adminRep;

        public EditCustomerModel(IAdmin adminRep)
        {
            this.adminRep = adminRep;
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null || adminRep.GetAllCustomers() == null)
            {
                return NotFound();
            }

            var customer = adminRep.GetByCustomerId(id);
            if (customer == null)
            {
                return NotFound();
            }
            Customer = customer;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

         
            try
            {
                adminRep.UpdateCustomer(customer);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(Customer.CustomerId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./ViewCustomers");
        }

        private bool CustomerExists(int id)
        {
            var customer = adminRep.GetByCustomerId(id);
            return customer != null;
        }
    }
}
