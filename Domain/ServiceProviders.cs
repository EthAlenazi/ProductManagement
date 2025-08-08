using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class ServiceProviders
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Phone]
        public string ContactNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }

   
}
