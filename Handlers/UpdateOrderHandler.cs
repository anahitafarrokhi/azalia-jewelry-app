using System.Drawing.Text;
using AzaliaJwellery.Commands;
using AzaliaJwellery.Interfaces;
using AzaliaJwellery.Models;
using AzaliaJwellery.Repositories;

namespace AzaliaJwellery.Handlers
{
    public class UpdateOrderHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateOrderHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(UpdateOrderCommand command)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(command.Id);
            if (order == null)
                throw new Exception("Order not found");
            order.Status = command.Status;
            order.OrderDetail.Quantity = command.OrderDetails.Quantity;

            _unitOfWork.Orders.Update(order);
            await _unitOfWork.SaveChangesAsync();
            

        }
    }
}
