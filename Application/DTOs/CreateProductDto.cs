
namespace Application.DTOs
{
    public record CreateProductDto(
        string Name,
        decimal Price,
        DateTime? CreationDate,
        int ServiceProviderId
    );
}
