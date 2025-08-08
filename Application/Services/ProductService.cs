
using Application.DTOs;
using Application.Interfaces;
using Domain.Models;

using Infrastructure.Interfaces;

namespace Application.Services
{

    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IServiceProviderRepository _providerRepository;

        public ProductService(IProductRepository productRepository, IServiceProviderRepository providerRepository)
        {
            _productRepository = productRepository;
            _providerRepository = providerRepository;
        }

        public async Task<int> CreateAsync(CreateProductDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new ArgumentException("Product name is required.");
            if (dto.Price <= 0)
                throw new ArgumentException("Price must be greater than zero.");

            var providerExists = (await _providerRepository.GetAll()).Any(p => p.Id == dto.ServiceProviderId);
            if (!providerExists)
                throw new InvalidOperationException("Service provider not found.");

            var product = new Product
            {
                Name = dto.Name.Trim(),
                Price = dto.Price,
                CreationDate = dto.CreationDate ?? DateTime.UtcNow,
                ServiceProviderId = dto.ServiceProviderId
            };

            await _productRepository.AddProduct(product);
            return product.Id;
        }

        public async Task<IReadOnlyList<Product>> GetFilteredAsync(ProductFilterDto filter)
        {
            var products = await _productRepository.GetFilteredProducts(
                filter.MinPrice,
                filter.MaxPrice,
                filter.FromDate,
                filter.ToDate,
                filter.ServiceProviderId
            );

            return products.ToList();
        }
    }

}
