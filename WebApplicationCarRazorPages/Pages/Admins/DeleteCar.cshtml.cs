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
    public class DeleteModel : PageModel
    {
        private readonly IAdmin adminRep;

        public DeleteModel(IAdmin adminRep)
        {
            this.adminRep = adminRep;
        }

        [BindProperty]
      public Car Car { get; set; } = default!;

       

        public IActionResult OnGet(int id)
        {
            if (id == null || adminRep.GetAllCars() == null)
            {
                return NotFound();
            }

            var car = adminRep.GetById(id);

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

        public IActionResult OnPost(int id)
        {
            if (id == null || adminRep.GetAllCars() == null)
            {
                return NotFound();
            }
            var car = adminRep.GetById(id);

            if (car != null)
            {
                Car = car;
                adminRep.DeleteCar(car);
            }

            return RedirectToPage("./ViewCars");
        }


    }
}
