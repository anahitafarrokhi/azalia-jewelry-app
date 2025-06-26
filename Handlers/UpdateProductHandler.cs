using AzaliaJwellery.Commands;
using AzaliaJwellery.Interfaces;

namespace AzaliaJwellery.Handlers
{
    public class UpdateProductHandler
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateProductCommand command)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(command.Id);
            if (product == null)
                throw new Exception("Product not found");

            product.Title = command.Title;
            product.Description = command.Description;
            product.Price = command.Price;
            product.ModifiedDate = DateTime.UtcNow;

            _unitOfWork.Products.Update(product);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
