using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Configuration;

namespace AzaliaJwellery.Models
{
    public class Orders
    {
        [Key]
        public int Id { get; set; } 

        [Required]
        public int UserId { get; set; } 

        [ForeignKey("UserId")]
        public Users User { get; set; }
        [Required]
        public decimal TotalAmount { get; set; }
        [Required]
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        [Required]
        [Column(TypeName="int")]
        public OrdersStatus Status { get; set; }

        public OrderDetail OrderDetail { get; set; }
    }

    public enum OrdersStatus
    {
        Pending = 0,       
        Processing = 1,    
        Shipped = 2,       
        Delivered = 3,     
        Cancelled = 4      
    }
}
