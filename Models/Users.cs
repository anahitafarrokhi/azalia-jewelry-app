using System.ComponentModel.DataAnnotations;
using System.Net;

namespace AzaliaJwellery.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; } 

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } 

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string? Email { get; set; }
        [Required]
        [Phone]
        [MaxLength(15)]
        public string? MobileNumber { get; set; }

        [Required]
        public string PasswordHash { get; set; } 

        [Required]
        [MaxLength(20)]
        public string Role { get; set; }
        public bool SentNewsOrNot { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; 

        // Navigation properties
        public ICollection<Orders> Orders { get; set; }

        public ICollection<Addresses> Addresses { get; set; }
    }
}
