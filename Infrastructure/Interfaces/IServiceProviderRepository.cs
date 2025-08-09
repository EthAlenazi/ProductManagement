using Domain.Models;

namespace Infrastructure.Interfaces
{
    public interface IServiceProviderRepository
    {
        Task<IEnumerable<ServiceProviders>> GetAll();
        Task Add(ServiceProviders provider);
        Task<ServiceProviders?> GetById(int id);
    }
}
