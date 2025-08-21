using AzaliaJwellery.Commands;
using AzaliaJwellery.Handlers;
using AzaliaJwellery.Interfaces;
using AzaliaJwellery.Models;
using AzaliaJwellery.Repositories;
using Azure.Core;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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
                Color = command.Color,
                LabOrNat = command.LabOrNat,
                LabOrNatDesc = command.LabOrNatDesc,
                Ayar = command.Ayar.Value,
                CaratWeight = command.Weight.Value,
                WeightDesc = command.WeightDesc,
                PackingDesc = command.PackingDesc,
                Style = command.Style,
                Cut = command.Cut,
                DiamondColor = command.DiamondColor,
                Clarity = command.Clarity,
                SheepingDesc = command.SheepingDesc,
                SetAsGift = command.SetAsGift,
                Symmetry = command.Symmetry,
                Fluorescence = command.Fluorescence,
                Dimensions = command.Dimensions,
                Table = command.Table,
                Depth = command.Depth,
                Polish = command.Polish,
                Width = command.Width,
                Price = command.Price.Value,
                Code = command.Code,
                Certificate = command.Certificate,
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
            if (command.Files != null && command.Files.Any())
            {
                foreach (var uploadedImage in command.Files)
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
                        ImageUrl = $"{baseUrl}/uploads/product-files/{uniqueFileName}",
                        IsPrimary = uploadedImage.IsPrimary,
                        ImageType = uploadedImage.ImageType,
                    });
                }
            }
            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.SaveChangesAsync(); //
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
            await _unitOfWork.SaveChangesAsync();
        }
    }
}

