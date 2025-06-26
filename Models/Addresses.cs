using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AzaliaJwellery.Models
{
    public class Addresses
    {
        [Key]
        public int   Id { get; set; }
        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public Users User { get; set; }
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }
        [Required]
        [MaxLength(255)]
        public string AddresseLine1 { get; set; }
        [MaxLength(255)]
        public string? AddresseLine2 { get; set; }
        [Required]
        [MaxLength(100)]
        public string City { get; set; }
        [MaxLength(100)]
        public string? State { get; set; }
        [Required]
        [MaxLength(20)]
        public string PostalCode { get; set; }
        [MaxLength(100)]
        [Required]
        public string Country { get; set; }
        public bool IsDefault { get; set; }
        [Column(TypeName = "int")]
        public AddressType AddressType { get; set; }
    }
}
public enum AddressType
{
    Delivery = 2,
    Billing = 1,
    Both = 0
}