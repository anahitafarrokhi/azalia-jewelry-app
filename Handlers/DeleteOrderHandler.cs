using AzaliaJwellery.Commands;
using AzaliaJwellery.Interfaces;
using AzaliaJwellery.Models;
using AzaliaJwellery.Repositories;

namespace AzaliaJwellery.Handlers
{
    public class DeleteOrderHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public DeleteOrderHandler( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(DeleteOrderCommand command)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(command.Id);
            if (order == null) {
                throw new Exception("Order not found");
            }
            _unitOfWork.Orders.Remove(order);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
