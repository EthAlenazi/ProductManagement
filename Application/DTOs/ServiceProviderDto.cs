using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public record ServiceProviderDto(
     int Id,
     string? Name,
     string? ContactNumber,
     string? Email
 );

}
