using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzaliaJwellery.Models
{
    public class CustomizationOption
    {
        public int Id { get; set; }
        [Required]
        public int ProductsId { get; set; }
        [ForeignKey("ProductsId")]
        public Products Products { get; set; }
        [Required]
        [MaxLength(100)]
        public string OptionName { get; set; }
        [Required]
        [MaxLength(100)]
        public string OptionValue { get; set; }
        public bool Deletable { get; set; }
    }
}


public enum OptionValue
{
    Engagement  = 0,
   
}