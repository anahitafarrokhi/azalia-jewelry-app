using AzaliaJwellery.Interfaces;
using AzaliaJwellery.Models;
using AzaliaJwellery.Queries;
using static AzaliaJwellery.Commands.CreateProductCommand;

namespace AzaliaJwellery.Handlers
{
    public class GetAllProductsHandler
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllProductsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ProductDto>> Handle()
        {
            var products = await _unitOfWork.Products.GetAllAsync();
            return products.Select(product => new  ProductDto
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
                BirthdayCategory = product.BirthdayCategory.ToString(),
                Gemstone = product.Gemstone.ToString(),

                Weight =product.CaratWeight,
                WeightDesc = product.WeightDesc,
                Width = product.Width,
                Code = product.Code,
                PackingDesc = product.PackingDesc,
                SheepingDesc = product.SheepingDesc,
                SetAsGift = product.SetAsGift,
                LabOrNatDesc = product.LabOrNatDesc,


                }).ToList();
        }
    }
}
