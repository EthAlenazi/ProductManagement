using System.ComponentModel.DataAnnotations;

namespace ProductManagement.Models
{
    public class ServiceProviderVm
    {
        
        public string Name { get; set; } = default!;
        public string? ContactNumber { get; set; }
        public string? Email { get; set; }
    }

}
