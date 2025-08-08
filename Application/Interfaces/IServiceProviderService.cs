using Domain.Models;

namespace Application.Interfaces
{

    public interface IServiceProviderService
    {
        Task<int> CreateAsync(string name, string? phone, string? email);
        Task<IReadOnlyList<ServiceProviders>> GetAllAsync();
    }
}
