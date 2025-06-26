using AzaliaJwellery.Commands;
using AzaliaJwellery.Interfaces;

namespace AzaliaJwellery.Handlers
{
    public class DeleteProductHandler
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteProductCommand command)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(command.Id);
            if (product == null)
                throw new Exception("Product not found");
            var images = await _unitOfWork.Images.GetByProductIdAsync(product.Id);
            if (images.Any())
                _unitOfWork.Images.Remove(images);

            _unitOfWork.Products.Remove(product);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
