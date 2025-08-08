using Domain.Models;

namespace ProductManagement.Models
{
    public class ProductsIndexVm
    {
        public IEnumerable<Product> Items { get; set; } = Enumerable.Empty<Product>();
        public ProductFilterVm Filter { get; set; } = new();
    }
}
