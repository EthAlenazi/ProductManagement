using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }
        public DateTime CreationDate { get; set; }

        public int ServiceProviderId { get; set; }
        public ServiceProviders ServiceProvider { get; set; }
    }
}
