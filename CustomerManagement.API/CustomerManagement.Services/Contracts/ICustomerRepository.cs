using CustomerManagement.Models;

namespace CustomerManagement.Repositories.Contracts
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAsync();

        Task<Customer> GetAsync(Guid identifier);

        Task<Customer> CreateAsync(Customer customer);

        Task<Customer> UpdateAsync(Customer customer);

        Task<bool> DeleteAsync(Guid identifier);
    }
}
