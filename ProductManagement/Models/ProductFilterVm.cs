using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ProductManagement.Models
{

    public class ProductFilterVm
    {
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? ServiceProviderId { get; set; }

        public IEnumerable<SelectListItem> Providers { get; set; } = new List<SelectListItem>();
    }

}
