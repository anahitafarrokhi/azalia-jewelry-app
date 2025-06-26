using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzaliaJwellery.Models
{
    public class ProductJewelleryType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Products Product { get; set; }

        [Required]
        public int JewelleryTypeId { get; set; }
        [ForeignKey("JewelleryTypeId")]
        public JewelleryType JewelleryType { get; set; }
    }
}
