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
    public class EditModel : PageModel
    {
        private readonly IAdmin adminRep;

       

        public EditModel(IAdmin adminRep)
        {
            this.adminRep = adminRep;
        }

        [BindProperty]
        public Car Car { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
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
            Car = car;

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(Car car)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            

            try
            {
                adminRep.UpdateCar(car);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(Car.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./ViewCars");
            
        }

        private bool CarExists(int id)
        {
            var car = adminRep.GetById(id);
            return car != null;
        }
    }
}
