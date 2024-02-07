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
    public class CustomerViewCarsModel : PageModel
    {
        private readonly ICustomer customerRep;

        public CustomerViewCarsModel(ICustomer customerRep)
        {
            this.customerRep = customerRep;
        }

        public IList<Car> Car { get; set; } = default!;

        public async Task OnGetAsync()
        {
            var viewAllCars = await customerRep.GetAllCars();

            if (viewAllCars != null)
            {
                Car = viewAllCars.ToList();
            }
        }
    }
}
