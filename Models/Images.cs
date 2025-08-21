using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzaliaJwellery.Models
{
    public class Images
    {
        public int Id { get; set; }
        
        [Required]
        public int ProductsId { get; set; }
        [ForeignKey("ProductsId")]
        public Products Products { get; set; }
        [Column(TypeName = "int")]
        public ImageType ImageType { get; set; }
        [Required]
        [MaxLength(255)]
        public string ImageUrl { get; set; } 

        public bool IsPrimary { get; set; } = false;
    }
    public enum ImageType
    {
        PackingGiftImg = 0,
        ProductImg = 1,
        CertificateFile = 2
    }
}
