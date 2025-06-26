using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzaliaJwellery.Models
{
    public class Payments
    {
        public int Id { get; set; }
        [Required]
        public int OrdersId { get; set; }
        [ForeignKey("OrdersId")]
        public Orders Orders { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public PaymentsMethod PaymentsMethod { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public PaymentsStatus PaymentsStatus { get; set; }
    }
    public enum PaymentsMethod
    {
        CreditCard = 0,
        PayPal = 1
    }
    public enum PaymentsStatus
    {
        Pending = 0,
        Completed = 1,
        Failed = 2,
    }
}
