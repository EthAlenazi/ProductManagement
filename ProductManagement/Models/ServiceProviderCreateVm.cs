using System.ComponentModel.DataAnnotations;

namespace ProductManagement.Models
{
    public class ServiceProviderCreateVm
    {
        [Required, MaxLength(100)]
        public string Name { get; set; } = default!;
        [Phone]
        public string? ContactNumber { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
    }

}
