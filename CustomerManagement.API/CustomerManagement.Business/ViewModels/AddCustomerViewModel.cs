using System.ComponentModel.DataAnnotations;

namespace CustomerManagement.Business.ViewModels
{
    public class AddCustomerViewModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
