using System.Reflection.Metadata;
using AzaliaJwellery.Commands;
using AzaliaJwellery.Interfaces;
using AzaliaJwellery.Models;
using AzaliaJwellery.Queries;
using AzaliaJwellery.Repositories;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace AzaliaJwellery.Handlers
{
    public class GetAllOrderHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllOrderHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<OrderDto>> Handle()
        {
            var oredrs = await _unitOfWork.Orders.GetAllAsync();
            return  oredrs.Select( order => new OrderDto()
            {
                Id = order.Id,
                User = new UserDto()
                {
                    Id = order.User.Id,
                    FirstName = order.User.FirstName,
                    LastName = order.User.LastName,
                    Email = order.User.Email,
                    SentNewsOrNot = order.User.SentNewsOrNot,
                    MobileNumber = order.User.MobileNumber,
                },
                TotalAmount = order.TotalAmount,
                OrderDate = order.OrderDate,
                Status = order.Status.ToString(),

                OrderDetail = new OrderDetailDto()
                {
                    Id = order.OrderDetail.Id,
                    Amount = order.OrderDetail.Amount,
                    Quantity = order.OrderDetail.Quantity,
                    ProductDto =new ProductDto()
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
                        //JewelleryType = new JewelleryTypeDto
                        //{
                        //    Id = order.OrderDetail.Products.JewelleryType.Id,
                        //    Name = order.OrderDetail.Products.JewelleryType.Name
                        //},
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
                        Gemstone = order.OrderDetail.Products.Gemstone.ToString(),
                        BirthdayCategory = order.OrderDetail.Products.BirthdayCategory.ToString(),
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
            }).ToList();
        }
    }
}
