using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CustomerManagement.Business.ViewModels
{
    public class UpdateCustomerViewModel
    {
        [JsonIgnore]
        public Guid Identifier { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
