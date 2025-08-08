using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{

    public record ProductFilterDto(
        decimal? MinPrice, decimal? MaxPrice,
        DateTime? FromDate, DateTime? ToDate,
        int? ServiceProviderId
    );
}
