using Bogus;
using CustomerManagement.Models;
using CustomerManagement.Models.Exceptions;
using CustomerManagement.Repositories.Contracts;
using System.Xml.Xsl;

namespace CustomerManagement.Repositories.Implementations
{
    public class CustomerRepository : ICustomerRepository
    {
        // Using in-memory store for customers
        private static List<Customer> customers { get; set; } = Helpers.GenerateDummyCustomers();

        public async Task<IEnumerable<Customer>> GetAsync()
        {
            return await Task.FromResult(customers);
        }

        public async Task<Customer> GetAsync(Guid identifier)
        {
            var customer = await Task.Run(() => customers.SingleOrDefault(x => x.Identifier == identifier));
            return customer ?? throw new CustomerNotFoundException();
        }

        public async Task<Customer> CreateAsync(Customer customer)
        {
            // Setting identifier here, as it will ideally be generated from DB/Store
            customer.Identifier = Guid.NewGuid();

            // Emulating async, as we don't really have an external store
            await Task.Run(() => customers.Add(customer));

            return customer;
        }

        public async Task<Customer> UpdateAsync(Customer customer)
        {
            // Since this is in-memory, replacing it with index. If a real data store, we might call StoredProc or deal with Entity (if EF Core) etc.
            var customerIndex = customers.FindIndex(m => m.Identifier == customer.Identifier);
            customers[customerIndex] = customer;

            return await Task.FromResult(customer);
        }

        public async Task<bool> DeleteAsync(Guid identifier)
        {
            var customer = await this.GetAsync(identifier);

            customers.Remove(customer);

            return true;
        }
    }
}
