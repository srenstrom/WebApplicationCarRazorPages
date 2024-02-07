using Microsoft.EntityFrameworkCore;

namespace WebApplicationCarRazorPages.Data
{
    public class CustomerRepository : ICustomer


    {
        private readonly WebApplicationCarRazorPagesContext webApplicationCarRazorPagesContext;

        public CustomerRepository(WebApplicationCarRazorPagesContext webApplicationCarRazorPagesContext)
        {
            this.webApplicationCarRazorPagesContext = webApplicationCarRazorPagesContext;
        }

        public Customer CheckCustomerUser(string email, string passWord)
        {

            Customer customer = webApplicationCarRazorPagesContext.Customers.Where(s => s.Email == email && s.Password == passWord)
                                   .FirstOrDefault<Customer>();
            return customer;

        }

        public async Task<IEnumerable<Car>> GetAllCars()
        {
            return await webApplicationCarRazorPagesContext.Cars.OrderBy(c => c.Brand).ToListAsync();
        }

        public Car GetById(int id)
        {
            return webApplicationCarRazorPagesContext.Cars.FirstOrDefault(c => c.Id == id);
        }
      

        public Customer GetByCustomerId(int? id)
        {
            return webApplicationCarRazorPagesContext.Customers.FirstOrDefault(c => c.CustomerId == id);
        }

        public Booking CreateBooking(Booking booking)
        {
            webApplicationCarRazorPagesContext.Booking.Add(booking);
            webApplicationCarRazorPagesContext.SaveChanges();
            return booking;
        }

        public Customer CreateCustomer(Customer customer)
        {
            webApplicationCarRazorPagesContext.Customers.Add(customer);
            webApplicationCarRazorPagesContext.SaveChanges();
            return customer;
        }

        public async Task<IEnumerable<Booking>> GetAllBookings()
        {
            return await webApplicationCarRazorPagesContext.Booking.Include(b => b.Car)
        .Include(b => b.Customer)
        .OrderBy(b => b.BookingId)
        .ToListAsync();
            
        }

        public Booking GetByBookingId(int id)
        {
            return webApplicationCarRazorPagesContext.Booking
        .Include(b => b.Customer)
        .Include(b => b.Car)
        .FirstOrDefault(b => b.BookingId == id);
        }

        public async Task DeleteBooking(Booking booking)
        {
            webApplicationCarRazorPagesContext.Booking.Remove(booking);
            await webApplicationCarRazorPagesContext.SaveChangesAsync();
        }

    }
}
