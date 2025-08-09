using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ProductManagement.Models
{
    public class ProductCreateVm
    {
        [Required, MaxLength(100)]
        public string Name { get; set; } = default!;
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }
        public DateTime? CreationDate { get; set; }
       public string? ServiceProviderName { get; set; }

        [Required]
        public int ServiceProviderId { get; set; }
        public IEnumerable<SelectListItem> Providers { get; set; } = Enumerable.Empty<SelectListItem>();
    }

}
