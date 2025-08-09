using Application.DTOs;
using Domain.Models;

namespace Application.Interfaces
{

    public interface IServiceProviderService
    {
        Task<IReadOnlyList<ServiceProviderDto>> GetAllAsync();
        Task<int> CreateAsync(CreateServiceProviderDto dto);
    }
}
