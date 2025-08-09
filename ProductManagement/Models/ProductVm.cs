using Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace ProductManagement.Models
{
    public class ProductVm
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
        public DateTime CreationDate { get; set; }
        public string ServiceProviderName { get; set; } = "";
       
    }
}
