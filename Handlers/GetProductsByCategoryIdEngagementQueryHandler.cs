using System.ComponentModel.DataAnnotations;
using AzaliaJwellery.Interfaces;
using AzaliaJwellery.Queries;
using MediatR;
using Microsoft.IdentityModel.Tokens;

public class GetProductsByCategoryIdEngagementQueryHandler
{
    private readonly IProductRepository _productRepository;

    public GetProductsByCategoryIdEngagementQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<ProductDto>> Handle(GetProductsByCategoryIdQuery request)
    {
        var products = await _productRepository.GetProductsByCategoryIdAsync(request);

        return products.Select(product => new ProductDto
        {
            Id = product.Id,
            Title = product.Title,
            Price = product.Price,
            Code = product.Code,
            Description = product.Description,
            Shape = product.Shape.ToString(),
            Style = product.Style.ToString(),
            Color = product.Color.ToString(),
            ImagePrimary = product.Images.Where(x => x.IsPrimary).Select(image => new ImageDto()
            {
                Id = image.Id,
                ImageUrl = image.ImageUrl,
            }).FirstOrDefault(),
           
            Polish = product.Polish,
            Symmetry = product.Symmetry,
            Fluorescence = product.Fluorescence,
            Dimensions = product.Dimensions,
            Table = product.Table,
            Depth = product.Depth,
            Certificate = product.Certificate,
            CertificateUrl = product.CertificateUrl,
            DiamondColor = product.DiamondColor.ToString(),
            Carat = product.CaratWeight.ToString(),
            Cut = product.Cut.ToString(),
            Clarity = product.Clarity.ToString(),

        }).ToList();
    }
}