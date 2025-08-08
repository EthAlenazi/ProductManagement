using Application.Interfaces;
using Domain.Models;
using Infrastructure.Interfaces;

namespace Application.Services
{
    public class ServiceProviderService : IServiceProviderService
    {
        private readonly IServiceProviderRepository _providerRepository;

        public ServiceProviderService(IServiceProviderRepository providerRepository)
        {
            _providerRepository = providerRepository;
        }

        public async Task<int> CreateAsync(string name, string? phone, string? email)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Service provider name is required.");

            var provider = new ServiceProviders
            {
                Name = name.Trim(),
                ContactNumber = phone,
                Email = email
            };

            await _providerRepository.Add(provider);
            return provider.Id;
        }

        public async Task<IReadOnlyList<ServiceProviders>> GetAllAsync()
        {
            var providers = await _providerRepository.GetAll();
            return providers.ToList();
        }
    }

}