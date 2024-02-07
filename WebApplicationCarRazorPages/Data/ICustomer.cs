namespace WebApplicationCarRazorPages.Data
{
    public interface ICustomer
    {
         Customer CheckCustomerUser(string userName, string passWord);

        Task<IEnumerable<Car>> GetAllCars();
        //Task<Car> GetById(int id);
        Car GetById(int id);

        public Customer GetByCustomerId(int? id);

        public Booking CreateBooking(Booking booking);

        Customer CreateCustomer(Customer customer);

        Task<IEnumerable<Booking>> GetAllBookings();
        Booking GetByBookingId(int id);

        Task DeleteBooking(Booking booking);



    }
}
