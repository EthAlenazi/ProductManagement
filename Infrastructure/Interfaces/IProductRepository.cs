using Domain.Models;

namespace Infrastructure.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetFilteredProducts(decimal? minPrice, decimal? maxPrice, DateTime? fromDate, DateTime? toDate, int? providerId);
        Task AddProduct(Product product);
    }
}
