using AzaliaJwellery.Interfaces;
using AzaliaJwellery.Models;
using AzaliaJwellery.Queries;

namespace AzaliaJwellery.Handlers
{
    public class GetProductByIdHandler
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetProductByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductDto> Handle(GetProductByIdQuery query)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(query.Id);


            if (product == null)
                throw new Exception("Product not found");

            return new ProductDto
            {
                Id = product.Id,
                Title = product.Title,
                Description = product.Description,
                Price = product.Price,
                Code = product.Code,
                productCategoryId = product.ProductCategory.Id,
                ProductCategory = new ProductCategoryDto
                {
                    Id = product.ProductCategory.Id,
                    Name = product.ProductCategory.Name
                },
                
                JewelleryTypes = product.ProductJewelleryTypes.Select(pjt => new JewelleryTypeDto
                {
                    Id = pjt.JewelleryType.Id,
                    Name = pjt.JewelleryType.Name
                }).ToList(),
                Images = product.Images.Select(image => new ImageDto
                {
                    Id = image.Id,
                    ImageUrl = image.ImageUrl,
                    IsPrimary = image.IsPrimary,
                    ImageType = (int)image.ImageType,
                }).ToList(),
                ColorInt = (int)product.Color,
                LabOrNatInt = (int)product.LabOrNat,
                LabOrNatDesc = product.LabOrNatDesc,
                AyarInt = (int)product.Ayar,
                Weight = product.CaratWeight,
                WeightDesc = product.WeightDesc,
                Width = product.Width,
                ProductGenderInt = (int)product.ProductGender,
                CountryMakerInt = (int)product.CountryMaker,
                ShapeInt = (int)product.Shape,
                DiamondColorInt = (int)product.DiamondColor,
                ClarityInt = (int)product.Clarity,
                CutInt = (int)product.Cut,
                GemstoneInt = (int)product.Gemstone,
                BirthdayCategoryInt = (int)product.BirthdayCategory,
                PackingDesc = product.PackingDesc,
                SheepingDesc = product.SheepingDesc,
                SetAsGift = product.SetAsGift,
                Polish = product.Polish,
                Symmetry = product.Symmetry,
                Fluorescence = product.Fluorescence,
                Dimensions = product.Dimensions,
                Table = product.Table,
                Depth = product.Depth,
                Certificate = product.Certificate,
                StyleInt = (int)product.Style
            };
        }
    }
}
