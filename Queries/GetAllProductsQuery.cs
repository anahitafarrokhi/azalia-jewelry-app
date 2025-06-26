using System.ComponentModel.DataAnnotations;

namespace AzaliaJwellery.Queries
{
    public class GetAllProductsQuery
    {
        
    }

    public class ProductDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ProductCategoryDto ProductCategory { get; set; }
        public JewelleryTypeDto JewelleryType { get; set; }
        public List<ImageDto> Images { get; set; }
        public ImageDto ImagePrimary { get; set; }
        public string Color { get; set; } // Enum as string
        public string LabOrNat { get; set; } // Enum as string
        public string Ayar { get; set; } // Enum as string
        public string ProductGender { get; set; } // Enum as string
        public string CountryMaker { get; set; } // Enum as string
        public string Shape { get; set; } // Enum as string
        public string Style { get; set; } // Enum as string
        public string Gemstone { get; set; } // Enum as string
        public string BirthdayCategory { get; set; } // Enum as string
        
        public decimal Weight { get; set; }
        public string? WeightDesc { get; set; }
        public decimal? Width { get; set; }
        public string Code { get; set; }
        public string? PackingDesc { get; set; }
        public string? SheepingDesc { get; set; }
        public bool SetAsGift { get; set; }
        public string? LabOrNatDesc { get; set; }
        public string Polish { get; set; }
        public string Symmetry { get; set; }
        public string Fluorescence { get; set; }
        public string Dimensions { get; set; }
        public string Table { get; set; }
        public string Depth { get; set; }
        public string Certificate { get; set; }
        public string CertificateUrl { get; set; }
        public string DiamondColor { get; set; }
        public string Cut { get; set; }
        public string Clarity { get; set; }
        public string Carat { get; set; }
        


    }
    public class ProductCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class JewelleryTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
 
    public class ImageDto
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public bool IsPrimary { get; set; }
    }
}
