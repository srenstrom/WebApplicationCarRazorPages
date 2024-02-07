namespace WebApplicationCarRazorPages.Data
{
    public interface IAdmin
    {
        Customer GetByCustomerId(int id);
        IEnumerable<Admin> GetAllAdmins();
        Admin GetByAdminId(string userName, string passWord);
       
        Car GetById(int id);

        IEnumerable<Car> GetAllCars();
       
        Task<IEnumerable<Booking>> GetAllBookings();

        Booking GetByBookingId(int id);
       

       Task DeleteBooking(Booking booking);

        Task<IEnumerable<Customer>> GetAllCustomers();

        void DeleteCustomer(Customer customer);

        void DeleteCar(Car car);

        Car CreateCar(Car car);

        Customer CreateCustomer(Customer customer);

        Car UpdateCar(Car car);

        Customer UpdateCustomer(Customer customer);
    }
}
