using Application.DTOs;
using Domain.Models;

namespace Application.Interfaces
{

    public interface IProductService
    {
        Task<int> CreateAsync(CreateProductDto dto);          
        Task<IReadOnlyList<Product>> GetFilteredAsync(ProductFilterDto filter);
    }

}
