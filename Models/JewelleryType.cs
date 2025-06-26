using System.ComponentModel.DataAnnotations;

namespace AzaliaJwellery.Models
{
    public class JewelleryType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(250)]
        public string? Desc { get; set; }
        public ICollection<ProductJewelleryType> ProductJewelleryTypes { get; set; }

    }
}
