using AzaliaJwellery.Models;
using AzaliaJwellery.Queries;
using Swashbuckle.AspNetCore.Annotations;

namespace AzaliaJwellery.Commands
{
    public class UpdateProductCommand
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int ProductCategoryId { get; set; }
        public ProductColor Color { get; set; }
        public LabOrNat LabOrNat { get; set; }
        public string? LabOrNatDesc { get; set; }
        public string? WeightDesc { get; set; }
        public string? PackingDesc { get; set; }
        public Ayar? Ayar { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Width { get; set; }
        public decimal? Price { get; set; }
        public string? Code { get; set; }
        public CountryMaker CountryMaker { get; set; }
        public ProductGender ProductGender { get; set; }
        public Style Style { get; set; }
        public Shape Shape { get; set; }
        public Cut Cut { get; set; }
        public DiamondColor DiamondColor { get; set; }
        public Clarity Clarity { get; set; }
        public BirthdayCategory BirthdayCategory { get; set; }

        public Gemstone Gemstone { get; set; }
        public List<int> JewelleryTypeIds { get; set; }
        public List<CreateImageDto>? Images { get; set; }
        public List<CreateFileDto>? Files { get; set; }
        public List<ImageDto>? ImagesListView { get; set; }
        public List<ImageDto>? FilesListView { get; set; }
        public string? SheepingDesc { get; set; }
        public bool SetAsGift { get; set; }
        public string? Polish { get; set; }
        public string? Symmetry { get; set; }
        public string? Fluorescence { get; set; }
        public string? Dimensions { get; set; }
        public string? Table { get; set; }
        public string? Depth { get; set; }
        public string? Certificate { get; set; }

       

        public class CreateImageDto
        {
            [SwaggerSchema(Format = "binary")]
            public IFormFile File { get; set; }
            public bool IsPrimary { get; set; }
            public ImageType ImageType { get; set; }

        }
        public class CreateFileDto
        {
            [SwaggerSchema(Format = "binary")]
            public IFormFile File { get; set; }
            public bool IsPrimary { get; set; }
            public ImageType ImageType { get; set; }

        }
    }
}
