using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Models;
using Infrastructure.Interfaces;

namespace Application.Services
{
    public class ServiceProviderService : IServiceProviderService
    {
        private readonly IServiceProviderRepository _repo;
        private readonly IMapper _mapper;

        public ServiceProviderService(IServiceProviderRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<ServiceProviderDto>> GetAllAsync()
        {
            var list = await _repo.GetAll(); 
            var dto = list.Select(sp => _mapper.Map<ServiceProviderDto>(sp)).ToList();
            return dto;
        }

        public async Task<int> CreateAsync(CreateServiceProviderDto dto)
        {
            var entity = _mapper.Map<ServiceProviders>(dto);

            await _repo.Add(entity);
            return  entity.Id;
        }

        
    }
}