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
    public class ViewCustomerModel : PageModel
    {
        private readonly IAdmin adminRep;

        public ViewCustomerModel(IAdmin adminRep)
        {
            this.adminRep = adminRep;
        }

        public IList<Customer> Customer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            var viewAllCustomers = await adminRep.GetAllCustomers();

            if (viewAllCustomers != null)
            {
                Customer = viewAllCustomers.ToList();
            }
        }
    }
}
