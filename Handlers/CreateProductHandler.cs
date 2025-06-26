using AzaliaJwellery.Commands;
using AzaliaJwellery.Handlers;
using AzaliaJwellery.Interfaces;
using AzaliaJwellery.Models;
using AzaliaJwellery.Repositories;
using Azure.Core;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AzaliaJwellery.Handlers
{
    public class CreateProductHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _environment;
        private readonly IConfiguration _configuration;

        
        public CreateProductHandler(IUnitOfWork unitOfWork, IWebHostEnvironment environment, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _environment = environment;
            _configuration = configuration;

        }

        public async Task Handle(CreateProductCommand command)
        {
            string imagesFolder = Path.Combine(_environment.WebRootPath, "uploads", "product-images");
            if (!Directory.Exists(imagesFolder))
            {
                Directory.CreateDirectory(imagesFolder);
            }
            var product = new Products
            {
                Title = command.Title,
                Description = command.Description,
                ProductCategoryId = command.ProductCategoryId,
                JewelleryTypeId = command.JewelleryTypeId,
                Color = command.Color,
                LabOrNat = command.LabOrNat,
                LabOrNatDesc = command.LabOrNatDesc,
                Ayar = command.Ayar.Value,
                CaratWeight = command.Weight,
                Width = command.Width,
                Price = command.Price,
                Code = command.Code,
                CountryMaker = command.CountryMaker,
                ProductGender = command.ProductGender,
                Shape = command.Shape,
                Gemstone = command.Gemstone,
                BirthdayCategory = command.BirthdayCategory,
                CreateDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,
                Images = new List<Images>()

            };
            if (command.Images == null || !command.Images.Any())
            {
                throw new Exception("A product must have at least one image.");
                
            }
                string baseUrl = _configuration["BaseUrl"];

            foreach (var uploadedImage in command.Images)
            {

                string fileExtension = Path.GetExtension(uploadedImage.File.FileName);
                if (string.IsNullOrEmpty(fileExtension))
                {
                    fileExtension = ".jpg"; // Default to .jpg if no extension is provided
                }
                string uniqueFileName = Guid.NewGuid().ToString() + fileExtension;
                string filePath = Path.Combine(imagesFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await uploadedImage.File.CopyToAsync(fileStream);
                }

                product.Images.Add(new Images
                {
                    ImageUrl = $"{baseUrl}/uploads/product-images/{uniqueFileName}",
                    IsPrimary = uploadedImage.IsPrimary,
                    ImageType = uploadedImage.ImageType,
                });
            }
            if (command.JewelleryTypeIds != null && command.JewelleryTypeIds.Any())
            {
                foreach (var jewelleryTypeId in command.JewelleryTypeIds)
                {
                    var productJewelleryType = new ProductJewelleryType
                    {
                        ProductId = product.Id, // The ID of the newly created product
                        JewelleryTypeId = jewelleryTypeId
                    };

                    _unitOfWork.ProductJewelleryType.AddAsync(productJewelleryType);
                }

            }
            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}

