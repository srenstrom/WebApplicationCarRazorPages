using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplicationCarRazorPages.Data;

namespace WebApplicationCarRazorPages.Data
{
    public class WebApplicationCarRazorPagesContext : DbContext
    {
        public WebApplicationCarRazorPagesContext (DbContextOptions<WebApplicationCarRazorPagesContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplicationCarRazorPages.Data.Car> Cars { get; set; } = default!;
        public DbSet<WebApplicationCarRazorPages.Data.Admin> Admins { get; set; } = default!;
        public DbSet<WebApplicationCarRazorPages.Data.Booking> Booking { get; set; } = default!;
        public DbSet<WebApplicationCarRazorPages.Data.Customer> Customers { get; set; } = default!;
    }
}
