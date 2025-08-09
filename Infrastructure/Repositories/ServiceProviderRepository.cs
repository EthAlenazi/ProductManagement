using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories
{

    public class ServiceProviderRepository : IServiceProviderRepository
    {
        private readonly AppDbContext _context;
        public ServiceProviderRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<ServiceProviders>> GetAll()
        {
            return await _context.ServiceProviders.ToListAsync();
        }

        public async Task Add(ServiceProviders provider)
        {
            _context.ServiceProviders.Add(provider);
            await _context.SaveChangesAsync();
        }
        public async Task<ServiceProviders?> GetById(int id)
        {
            return await _context.ServiceProviders
                .FirstOrDefaultAsync(sp => sp.Id == id);
        }

    }
}
