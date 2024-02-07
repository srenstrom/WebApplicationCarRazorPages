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
    public class ViewBookingsModel : PageModel
    {
        private readonly IAdmin adminRep;

        public ViewBookingsModel(IAdmin adminRep)
        {
            this.adminRep = adminRep;
        }

        public IList<Booking> Booking { get;set; } = default!;

        public async Task OnGetAsync()
        {
            var viewAllBookings = await adminRep.GetAllBookings();

            if (viewAllBookings != null)
            {
                Booking = viewAllBookings.ToList();
                
            }
        }
    }
}
