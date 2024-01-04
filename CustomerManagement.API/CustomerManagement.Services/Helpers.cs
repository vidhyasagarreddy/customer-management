using Bogus;
using CustomerManagement.Models;

namespace CustomerManagement.Repositories
{
    public class Helpers
    {
        public static List<Customer> GenerateDummyCustomers(int count = 20)
        {
            var customerFaker = new Faker<Customer>()
                                    .RuleFor(c => c.Identifier, f => f.Random.Guid())
                                    .RuleFor(c => c.FirstName, f => f.Person.FirstName)
                                    .RuleFor(c => c.LastName, f => f.Person.LastName)
                                    .RuleFor(c => c.Email, f => f.Person.Email)
                                    .RuleFor(c => c.CreatedOn, f => DateTime.UtcNow.AddDays(-1));

            return customerFaker.Generate(count);
        }
    }
}
