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
    public class LoginIndexModel : PageModel
    {
        private readonly IAdmin adminRep;

        public LoginIndexModel(IAdmin adminRep)
        {
            this.adminRep = adminRep;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Admin Admin { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            
            var admin = adminRep.GetByAdminId(Admin.Email, Admin.Password);
            if (!ModelState.IsValid || admin == null)
            {
                TempData["ErrorMessage"] = "Felaktiga inloggningsuppgifter. Vänligen försök igen.";
                return RedirectToPage("./LoginIndex");
            }


            return RedirectToPage("./StartIndex");
        }
    }
}
