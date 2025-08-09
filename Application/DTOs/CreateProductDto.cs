
namespace Application.DTOs
{
    public record CreateProductDto(
    string Name,
    decimal Price,
    DateTime? CreationDate, 
    string ServiceProviderName,
    int ServiceProviderId
);
}
