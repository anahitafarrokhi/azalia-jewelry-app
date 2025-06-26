using System.Diagnostics.Metrics;
using System.Drawing.Text;
using System.Net;
using AzaliaJwellery.Commands;
using AzaliaJwellery.Interfaces;
using AzaliaJwellery.Models;
using AzaliaJwellery.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Mono.TextTemplating;

namespace AzaliaJwellery.Handlers
{
    public class UpdatePaymentHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdatePaymentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(UpdatePaymentCommand command)
        {
            var payment = await _unitOfWork.Payments.GetByIdAsync(command.Id);
            if (payment == null)
                throw new Exception("Payment not found");

            payment.Amount = command.Amount;
            payment.PaymentsMethod = command.PaymentsMethod;
            payment.PaymentsStatus = command.PaymentsStatus;

            _unitOfWork.Payments.Update(payment);
            await _unitOfWork.SaveChangesAsync();


        }
    }
}