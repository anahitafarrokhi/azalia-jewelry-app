using AzaliaJwellery.Interfaces;
using AzaliaJwellery.Models;
using AzaliaJwellery.Queries;

namespace AzaliaJwellery.Handlers
{
    public class GetOrderByIdHandler
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetOrderByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

       public async Task<OrderDto> Handle(GetOrderByIdQuery query)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(query.Id);

            return new OrderDto()
            {
                Id = order.Id,
                User = new UserDto()
                {
                    Id = order.User.Id,
                    FirstName = order.User.FirstName,
                    LastName = order.User.LastName,
                    Email = order.User.Email,
                    MobileNumber = order.User.MobileNumber,
                    SentNewsOrNot = order.User.SentNewsOrNot,
                },
                TotalAmount = order.TotalAmount,
                OrderDate = order.OrderDate,
                Status = order.Status.ToString(),

                OrderDetail = new OrderDetailDto()
                {
                    Id = order.OrderDetail.Id,
                    Amount = order.OrderDetail.Amount,
                    Quantity = order.OrderDetail.Quantity,
                    ProductDto = new ProductDto()
                    {
                        Id = order.OrderDetail.Products.Id,
                        Title = order.OrderDetail.Products.Title,
                        Description = order.OrderDetail.Products.Description,
                        Price = order.OrderDetail.Products.Price,
                        ProductCategory = new ProductCategoryDto
                        {
                            Id = order.OrderDetail.Products.ProductCategory.Id,
                            Name = order.OrderDetail.Products.ProductCategory.Name
                        },
                        JewelleryType = new JewelleryTypeDto
                        {
                            Id = order.OrderDetail.Products.JewelleryType.Id,
                            Name = order.OrderDetail.Products.JewelleryType.Name
                        },
                        Images = order.OrderDetail.Products.Images.Select(image => new ImageDto
                        {
                            Id = image.Id,
                            ImageUrl = image.ImageUrl,
                            IsPrimary = image.IsPrimary
                        }).ToList(),
                        Color = order.OrderDetail.Products.Color.ToString(),
                        LabOrNat = order.OrderDetail.Products.LabOrNat.ToString(),
                        Ayar = order.OrderDetail.Products.Ayar.ToString(),
                        ProductGender = order.OrderDetail.Products.ProductGender.ToString(),
                        CountryMaker = order.OrderDetail.Products.CountryMaker.ToString(),
                        Shape = order.OrderDetail.Products.Shape.ToString(),
                        BirthdayCategory = order.OrderDetail.Products.BirthdayCategory.ToString(),
                        Gemstone = order.OrderDetail.Products.Gemstone.ToString(),
                        Weight = order.OrderDetail.Products.CaratWeight,
                        WeightDesc = order.OrderDetail.Products.WeightDesc,
                        Width = order.OrderDetail.Products.Width,
                        Code = order.OrderDetail.Products.Code,
                        PackingDesc = order.OrderDetail.Products.PackingDesc,
                        SheepingDesc = order.OrderDetail.Products.SheepingDesc,
                        SetAsGift = order.OrderDetail.Products.SetAsGift,
                        LabOrNatDesc = order.OrderDetail.Products.LabOrNatDesc,
                    }

                }
            };

        }
    }
}
