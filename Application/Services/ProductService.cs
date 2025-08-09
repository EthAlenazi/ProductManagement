
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Models;
using Infrastructure.Interfaces;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IServiceProviderRepository _providerRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IServiceProviderRepository providerRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _providerRepository = providerRepository;
            _mapper = mapper;
        }

        public async Task<int> CreateAsync(CreateProductDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new ArgumentException("Product name is required.");
            if (dto.Price <= 0)
                throw new ArgumentException("Price must be greater than zero.");

            
            var provider = await _providerRepository.GetById(dto.ServiceProviderId);
            if (provider is null)
                throw new InvalidOperationException("Service provider not found.");

            var product = new Product
            {
                Name = dto.Name.Trim(),
                Price = dto.Price,
                CreationDate = dto.CreationDate ?? DateTime.UtcNow,
                ServiceProviderId= dto.ServiceProviderId
            };

            await _productRepository.AddProduct(product);
            return product.Id;
        }

        public async Task<IReadOnlyList<ProductDto>> GetFilteredAsync(ProductFilterDto filter)
        {
            var products = await _productRepository.GetFilteredProducts(
                filter.MinPrice,
                filter.MaxPrice,
                filter.FromDate,
                filter.ToDate,
                filter.ServiceProviderId
            );
            var result = _mapper.Map<List<ProductDto>>(products);
            return result;
        }
    }
}



