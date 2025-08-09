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
            var query = _context.Products
                .Include(p => p.ServiceProvider) 
                .AsQueryable();

            if (min.HasValue)
                query = query.Where(p => p.Price >= min.Value);
            if (max.HasValue)
                query = query.Where(p => p.Price <= max.Value);
            if (from.HasValue)
                query = query.Where(p => p.CreationDate >= from.Value);
            if (to.HasValue)
                query = query.Where(p => p.CreationDate <= to.Value);
            if (providerId.HasValue)
                query = query.Where(p => p.ServiceProviderId == providerId.Value);
            var result = await query.ToListAsync();

            // إذا النتيجة فاضية → رجّع كل المنتجات
            if (!result.Any())
            {
                result = await _context.Products
                    .Include(p => p.ServiceProvider)
                    .ToListAsync();
            }

            return result;
        }

        public async Task AddProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task<Product?> GetById(int id)
        {
            return await _context.Products
                .Include(p => p.ServiceProvider) 
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }

}
