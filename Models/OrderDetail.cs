using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace AzaliaJwellery.Models
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OrdersId { get; set; }

        [ForeignKey("OrdersId")]
        public Orders Orders { get; set; }
        [Required]
        public int ProductId { get; set; }
        public int ProductDiamondId { get; set; }

        [ForeignKey("ProductId")]
        public Products Products { get; set; }
        [Required]

        public decimal Amount { get; set; }
        [Required]

        public int Quantity { get; set; }
        public decimal Size { get; set; }
        [Column(TypeName = "int")]

        public GemStone GemStone { get; set; }
        public string Engraving { get; set; }
    }
    public enum GemStone
    {
        Diamond = 1,
        Ruby = 2,
        Emerald = 3,
        PinkSapphire = 4,
        BlueSapphire = 5,
        YellowSapphire = 6,

    }
}
