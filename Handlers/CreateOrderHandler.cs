using AzaliaJwellery.Commands;
using AzaliaJwellery.Interfaces;
using AzaliaJwellery.Models;
using AzaliaJwellery.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AzaliaJwellery.Handlers
{
    public class CreateOrderHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateOrderHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(CreateOrderCommand command)
        {
            
            // Validate the product exists
            var productExists = await _unitOfWork.Products.AnyAsync(command.OrderDetails.ProductId);
            if (!productExists)
            {
                throw new Exception("Product not found.");
            }
            var order = new Orders()
            {
                UserId = command.UserId,
                TotalAmount = command.TotalAmount,
                OrderDate = DateTime.Now,
                Status = OrdersStatus.Pending,
                OrderDetail = new OrderDetail()
                {
                    ProductId = command.OrderDetails.ProductId,
                    Amount = command.OrderDetails.Amount,
                    Quantity = command.OrderDetails.Quantity
                }
            };
            await _unitOfWork.Orders.AddAsync(order);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
