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

        public async Task<IEnumerable<ServiceProviders>> GetAll() => await _context.ServiceProviders.ToListAsync();

        public async Task Add(ServiceProviders provider)
        {
            _context.ServiceProviders.Add(provider);
            await _context.SaveChangesAsync();
        }

    }
}
