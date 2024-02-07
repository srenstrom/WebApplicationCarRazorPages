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
    public class IndexModel : PageModel
    {
        private readonly IAdmin adminRep;

        public IndexModel(IAdmin adminRep)
        {
            this.adminRep = adminRep;
        }

        public IList<Car> Car { get;set; } = default!;

     

        public void OnGet()
        {
            var viewAllCars = adminRep.GetAllCars();

            if (viewAllCars != null)
            {
                Car = viewAllCars.ToList();
            }
         
        }
            
    }
}
