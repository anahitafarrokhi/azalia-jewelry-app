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
            return new ProductDto
            {
                Id = product.Id,
                Title = product.Title,
                Description = product.Description,
                Price = product.Price,
                ProductCategory = new ProductCategoryDto
                {
                    Id = product.ProductCategory.Id,
                    Name = product.ProductCategory.Name
                },
                JewelleryType = new JewelleryTypeDto
                {
                    Id = product.JewelleryType.Id,
                    Name = product.JewelleryType.Name
                },
                Images = product.Images.Select(image => new ImageDto
                {
                    Id = image.Id,
                    ImageUrl = image.ImageUrl,
                    IsPrimary = image.IsPrimary
                }).ToList(),
                Color = product.Color.ToString(),
                LabOrNat = product.LabOrNat.ToString(),
                Ayar = product.Ayar.ToString(),
                ProductGender = product.ProductGender.ToString(),
                CountryMaker = product.CountryMaker.ToString(),
                Shape = product.Shape.ToString(),
                Gemstone = product.Gemstone.ToString(),
                BirthdayCategory = product.BirthdayCategory.ToString(),

                Weight = product.CaratWeight,
                WeightDesc = product.WeightDesc,
                Width = product.Width,
                Code = product.Code,
                PackingDesc = product.PackingDesc,
                SheepingDesc = product.SheepingDesc,
                SetAsGift = product.SetAsGift,
                LabOrNatDesc = product.LabOrNatDesc,

            };
        }
    }
}
