using Microsoft.EntityFrameworkCore;

namespace WebApplicationCarRazorPages.Data
{
    public class AdminRepository : IAdmin
    {
        private readonly WebApplicationCarRazorPagesContext webApplicationCarRazorPagesContext;

        public AdminRepository(WebApplicationCarRazorPagesContext webApplicationCarRazorPagesContext)
        {
            this.webApplicationCarRazorPagesContext = webApplicationCarRazorPagesContext;
        }

        public Car CreateCar(Car car)
        {
            webApplicationCarRazorPagesContext.Add(car);
            webApplicationCarRazorPagesContext.SaveChanges();
            return car;
        }

        public void DeleteCar(Car car)
        {
            webApplicationCarRazorPagesContext.Cars.Remove(car);
            webApplicationCarRazorPagesContext.SaveChanges();
        }

        public void DeleteCustomer(Customer customer)
        {
            webApplicationCarRazorPagesContext.Customers.Remove(customer);
            webApplicationCarRazorPagesContext.SaveChanges();
        }

      

        public IEnumerable<Car> GetAllCars()
        {
            return webApplicationCarRazorPagesContext.Cars.OrderBy(c => c.Brand);
        }


        public async Task<IEnumerable<Customer>>GetAllCustomers()
        {
            return webApplicationCarRazorPagesContext.Customers.OrderBy(c => c.LastName);
        }

        public Car GetById(int id)
        {
            return webApplicationCarRazorPagesContext.Cars.FirstOrDefault(c => c.Id == id);
        }

        public Customer GetByCustomerId(int id)
        {
            return webApplicationCarRazorPagesContext.Customers.FirstOrDefault(c => c.CustomerId == id);
        }


        public Car UpdateCar(Car car)
        {
            webApplicationCarRazorPagesContext.Cars.Update(car);
            webApplicationCarRazorPagesContext.SaveChanges();
            return car;


        }


        public Customer CreateCustomer(Customer customer)
        {
            webApplicationCarRazorPagesContext.Customers.Add(customer);
            webApplicationCarRazorPagesContext.SaveChanges();
            return customer;
        }

        public Customer UpdateCustomer(Customer customer)
        {
            webApplicationCarRazorPagesContext.Update(customer);
            webApplicationCarRazorPagesContext.SaveChanges();
            return customer;
        }

        public Admin GetByAdminId(string userName, string passWord)
        {
            Admin admin = webApplicationCarRazorPagesContext.Admins.Where(s => s.Email == userName && s.Password == passWord)
                                   .FirstOrDefault<Admin>();
            return admin;
        }

        public IEnumerable<Admin> GetAllAdmins()
        {
            return webApplicationCarRazorPagesContext.Admins.OrderBy(c => c.Email);
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
