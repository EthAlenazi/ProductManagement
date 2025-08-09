using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public record ProductDto(
    int Id,
    string Name,
    decimal Price,
    DateTime CreationDate,
    int ServiceProviderId,
    string ServiceProviderName
);
}
