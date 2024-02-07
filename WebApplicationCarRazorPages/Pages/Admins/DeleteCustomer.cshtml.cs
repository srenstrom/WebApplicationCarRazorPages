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
    public class DeleteCustomerModel : PageModel
    {
        private readonly IAdmin adminRep;

        public DeleteCustomerModel(IAdmin adminRep)
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
            else
            {
                Customer = customer;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null || adminRep.GetAllCustomers() == null)
            {
                return NotFound();
            }
            var customer = adminRep.GetByCustomerId(id);

            if (customer != null)
            {
                Customer = customer;
                adminRep.DeleteCustomer(customer);
            }

            return RedirectToPage("./ViewCustomers");
        }
    }
}
