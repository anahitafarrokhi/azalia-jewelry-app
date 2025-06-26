using AzaliaJwellery.Commands;
using AzaliaJwellery.Interfaces;
using AzaliaJwellery.Models;
using AzaliaJwellery.Repositories;

namespace AzaliaJwellery.Handlers
{
    public class DeletePaymentHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public DeletePaymentHandler( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(DeletePaymentCommand command)
        {
            var payment = await _unitOfWork.Payments.GetByIdAsync(command.Id);
            if (payment == null) {
                throw new Exception("Payment not found");
            }
            _unitOfWork.Payments.Remove(payment);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
