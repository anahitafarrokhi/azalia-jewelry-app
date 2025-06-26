using AzaliaJwellery.Models;
using Swashbuckle.AspNetCore.Annotations;


namespace AzaliaJwellery.Commands
{
    public class CreateProductCommand
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int ProductCategoryId { get; set; }
        public int JewelleryTypeId { get; set; }
        public ProductColor Color { get; set; }
        public LabOrNat LabOrNat { get; set; }
        public string LabOrNatDesc { get; set; }
        public Ayar? Ayar { get; set; }
        public decimal Weight { get; set; }
        public decimal Width { get; set; }
        public decimal Price { get; set; }
        public string Code { get; set; }
        public CountryMaker CountryMaker { get; set; }
        public ProductGender ProductGender { get; set; }
        public Shape Shape { get; set; }
        public BirthdayCategory BirthdayCategory { get; set; }
        
        public Gemstone Gemstone { get; set; }
        public List<int>  JewelleryTypeIds { get; set; }
        public List<CreateImageDto> Images { get; set; } 



        public class CreateImageDto
        {
            [SwaggerSchema(Format = "binary")]
            public IFormFile File { get; set; }
            public bool IsPrimary { get; set; }
            public string ImageUrl { get; set; }
            public ImageType ImageType { get; set; }

        }
    }
}
