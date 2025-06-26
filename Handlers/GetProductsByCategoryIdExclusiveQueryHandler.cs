using AzaliaJwellery.Interfaces;
using AzaliaJwellery.Queries;
using MediatR;

public class GetProductsByCategoryIdExclusiveQueryHandler
{
    private readonly IProductRepository _productRepository;

    public GetProductsByCategoryIdExclusiveQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<ProductDto>> Handle(GetProductsByCategoryIdQuery request)
    {
        var products = await _productRepository.GetProductsByCategoryIdExclusiveAsync(request.CategoryId);

        return products.Select(product => new ProductDto
        {
            Id = product.Id,
            Title = product.Title,
            Price = product.Price,
            ImagePrimary = product.Images.Where(x => x.IsPrimary).Select(image => new ImageDto()
            {
                Id = image.Id,
                ImageUrl = image.ImageUrl,
            }).FirstOrDefault(),
        }).ToList();
    }
}