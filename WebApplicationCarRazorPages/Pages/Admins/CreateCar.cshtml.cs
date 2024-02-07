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
    public class CreateModel : PageModel
    {
        private readonly IAdmin adminRep;


        public CreateModel(IAdmin adminRep)
        {
            this.adminRep = adminRep;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Car Car { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost(Car car)
        {
          if (!ModelState.IsValid || car == null)
            {
                return Page();
            }

            adminRep.CreateCar(car);

            return RedirectToPage("./ViewCars");
        }
    }
}
