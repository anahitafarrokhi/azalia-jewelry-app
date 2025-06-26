using AzaliaJwellery.Commands;
using AzaliaJwellery.Interfaces;
using AzaliaJwellery.Models;
using AzaliaJwellery.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AzaliaJwellery.Handlers
{
    public class CreatePaymentHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreatePaymentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(CreatePaymentCommand command)
        {
            var payments = new Payments()
            {
                
                PaymentsStatus = command.PaymentsStatus,
                PaymentsMethod = command.PaymentsMethod,
                Amount = command.Amount,
                OrdersId = command.OrdersId

            };
            await _unitOfWork.Payments.AddAsync(payments);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}