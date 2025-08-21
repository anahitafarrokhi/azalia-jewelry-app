using AzaliaJwellery.Commands;
using AzaliaJwellery.Interfaces;
using AzaliaJwellery.Models;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;



namespace AzaliaJwellery.Handlers
{
    public class UpdateProductHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _environment;
        private readonly IConfiguration _configuration;

        public UpdateProductHandler(IUnitOfWork unitOfWork, IWebHostEnvironment environment, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _environment = environment;
            _configuration = configuration;

        }

        public async Task Handle(UpdateProductCommand command)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(command.Id);
            if (product == null)
                throw new Exception("Product not found");




            string imagesFolder = Path.Combine(_environment.WebRootPath, "uploads", "product-images");
            if (!Directory.Exists(imagesFolder))
            {
                Directory.CreateDirectory(imagesFolder);
            }

            product.Title = command.Title;
            product.Description = command.Description;
            product.ProductCategoryId = command.ProductCategoryId;
            product.Color = command.Color;
            product.LabOrNat = command.LabOrNat;
            product.LabOrNatDesc = command.LabOrNatDesc;
            product.Ayar = command.Ayar.Value;
            product.CaratWeight = command.Weight.Value;
            product.WeightDesc = command.WeightDesc;
            product.PackingDesc = command.PackingDesc;
            product.Style = command.Style;
            product.Cut = command.Cut;
            product.DiamondColor = command.DiamondColor;
            product.Clarity = command.Clarity;
            product.SheepingDesc = command.SheepingDesc;
            product.SetAsGift = command.SetAsGift;
            product.Symmetry = command.Symmetry;
            product.Fluorescence = command.Fluorescence;
            product.Dimensions = command.Dimensions;
            product.Table = command.Table;
            product.Depth = command.Depth;
            product.Polish = command.Polish;
            product.Width = command.Width;
            product.Price = command.Price.Value;
            product.Code = command.Code;
            product.Certificate = command.Certificate;
            product.CountryMaker = command.CountryMaker;
            product.ProductGender = command.ProductGender;
            product.Shape = command.Shape;
            product.Gemstone = command.Gemstone;
            product.BirthdayCategory = command.BirthdayCategory;
            product.CreateDate = DateTime.UtcNow;
            product.ModifiedDate = DateTime.UtcNow;
            product.Images = new List<Images>();
            string baseUrl = _configuration["BaseUrl"];
            var imagesProduct = await _unitOfWork.Images.GetByProductIdAsync(command.Id);
            if (imagesProduct.Any())
            {
                foreach (var item in imagesProduct)
                {
                    if (!(command.FilesListView?.Any(x => x.Id == item.Id) ?? false) &&
                       !(command.ImagesListView?.Any(x => x.Id == item.Id) ?? false))
                    {
                        product.Images.Add(item);
                    }
                }
                if (product.Images.Count>0) 
                _unitOfWork.Images.Remove(product.Images);
            }

            if (command.Images != null && command.Images.Any())
            {


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
                        ProductsId = product.Id,
                    });
                }

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
                        ProductsId = product.Id,

                    });
                }
            }
            if (product.Images.Count > 0)
                await _unitOfWork.Images.AddAsync(product.Images.ToList());
            _unitOfWork.Products.Update(product);
            await _unitOfWork.SaveChangesAsync();



            var existingLinks = product.ProductJewelleryTypes?.ToList()
                                ?? new List<ProductJewelleryType>();

            if (existingLinks.Count > 0)
            {
                _unitOfWork.ProductJewelleryType.Remove(existingLinks);
                await _unitOfWork.SaveChangesAsync();
            }
            // Add new links (distinct to avoid duplicates)
            if (command.JewelleryTypeIds != null && command.JewelleryTypeIds.Any())
            {
                foreach (var jewelleryTypeId in command.JewelleryTypeIds.Distinct())
                {
                    var link = new ProductJewelleryType
                    {
                        ProductId = product.Id,
                        JewelleryTypeId = jewelleryTypeId
                    };
                    await _unitOfWork.ProductJewelleryType.AddAsync(link);
                }
                await _unitOfWork.SaveChangesAsync();
            }


        }
    }
}
