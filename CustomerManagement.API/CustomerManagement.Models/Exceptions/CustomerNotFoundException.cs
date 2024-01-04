namespace CustomerManagement.Models.Exceptions
{
    public class CustomerNotFoundException : Exception
    {
        public CustomerNotFoundException() : base("Customer Not Found")
        {
        }
    }
}
