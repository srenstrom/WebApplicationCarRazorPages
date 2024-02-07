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
    public class DetailsModel : PageModel
    {
        private readonly ICustomer customerRep;

        public DetailsModel(ICustomer customerRep)
        {
            this.customerRep = customerRep;
        }

        public Car Car { get; set; } = default!;

        

        public IActionResult OnGet(int id)
        {

            var car =  customerRep.GetById(id);
            if (car == null)
            {
                return NotFound();
            }
            else
            {
                Car = car;
            }
            return Page();
        }
    }
}
