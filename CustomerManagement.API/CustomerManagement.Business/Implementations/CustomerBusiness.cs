using AutoMapper;
using CustomerManagement.Business.Contracts;
using CustomerManagement.Business.ViewModels;
using CustomerManagement.Models;
using CustomerManagement.Repositories.Contracts;

namespace CustomerManagement.Business.Implementations
{
    public class CustomerBusiness : ICustomerBusiness
    {
        private readonly IMapper mapper;

        private readonly ICustomerRepository customerRepository;

        public CustomerBusiness(IMapper mapper, ICustomerRepository customerService)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.customerRepository = customerService ?? throw new ArgumentNullException(nameof(customerService));
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await this.customerRepository.GetAsync();
        }

        public async Task<Customer> AddCustomerAsync(AddCustomerViewModel customer)
        {
            var _customer = this.mapper.Map<Customer>(customer);

            // Set Created Datetime
            _customer.CreatedOn = DateTime.UtcNow;

            return await this.customerRepository.CreateAsync(_customer);
        }

        public async Task<Customer> UpdateCustomerAsync(UpdateCustomerViewModel customer)
        {
            // Validate if Customer exists (GetAsync will do this internally)
            var _customer = await this.customerRepository.GetAsync(customer.Identifier);

            _customer.FirstName = customer.FirstName;
            _customer.LastName = customer.LastName;
            _customer.Email = customer.Email;

            // Set Modified date during Update
            _customer.ModifiedOn = DateTime.UtcNow;

            await this.customerRepository.UpdateAsync(_customer);

            return _customer;
        }

        public async Task<bool> DeleteCustomerAsync(Guid identifier)
        {
            return await this.customerRepository.DeleteAsync(identifier);
        }
    }
}
