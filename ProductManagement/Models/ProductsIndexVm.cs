using Domain.Models;

namespace ProductManagement.Models
{
    public class ProductsIndexVm
    {
        public IReadOnlyList<ProductVm> Items { get; set; } = new List<ProductVm>();
        public ProductFilterVm Filter { get; set; } = new();
    }
}
