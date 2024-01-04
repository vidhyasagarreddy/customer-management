using CustomerManagement.Business.ViewModels;
using CustomerManagement.Models;

namespace CustomerManagement.Business.Contracts
{
    public interface ICustomerBusiness
    {
        Task<IEnumerable<Customer>> GetCustomersAsync();

        Task<Customer> AddCustomerAsync(AddCustomerViewModel customer);

        Task<Customer> UpdateCustomerAsync(UpdateCustomerViewModel customer);

        Task<bool> DeleteCustomerAsync(Guid identifier);
    }
}
