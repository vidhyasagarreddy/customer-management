using CustomerManagement.Business.Contracts;
using CustomerManagement.Business.ViewModels;
using CustomerManagement.Models;
using CustomerManagement.Models.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CustomerManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerBusiness customerBusiness;

        public CustomersController(ICustomerBusiness customerBusiness)
        {
            this.customerBusiness = customerBusiness ?? throw new ArgumentNullException(nameof(customerBusiness));
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<Customer>))]
        public async Task<IActionResult> GetCustomersAsync()
        {
            return this.Ok(await this.customerBusiness.GetCustomersAsync());
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Customer))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> AddCustomerAsync([FromBody] AddCustomerViewModel customer)
        {
            return this.Ok(await this.customerBusiness.AddCustomerAsync(customer));
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Customer))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateCustomerAsync([FromBody] UpdateCustomerViewModel customer, Guid id)
        {
            // Set customer id from route.
            customer.Identifier = id;
            try
            {
                var _customer = await this.customerBusiness.UpdateCustomerAsync(customer);
                return this.Ok(_customer);
            }
            catch (CustomerNotFoundException)
            {
                return this.BadRequest($"Customer not found with Id: {id}");
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateCustomerAsync(Guid id)
        {
            try
            {
                var isCustomerDeleted = await this.customerBusiness.DeleteCustomerAsync(id);
                return this.Ok(isCustomerDeleted);
            }
            catch (CustomerNotFoundException)
            {
                return this.BadRequest($"Customer not found with Id: {id}");
            }
        }
    }
}
