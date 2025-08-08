using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Product>> GetFilteredProducts(decimal? min, decimal? max, DateTime? from, DateTime? to, int? providerId)
        {
            var query = _context.Products.Include(p => p.ServiceProvider).AsQueryable();

            if (min.HasValue) query = query.Where(p => p.Price >= min);
            if (max.HasValue) query = query.Where(p => p.Price <= max);
            if (from.HasValue) query = query.Where(p => p.CreationDate >= from);
            if (to.HasValue) query = query.Where(p => p.CreationDate <= to);
            if (providerId.HasValue) query = query.Where(p => p.ServiceProviderId == providerId);

            return await query.ToListAsync();
        }

        public async Task AddProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }
    }

}
