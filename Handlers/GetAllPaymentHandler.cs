using System.Reflection.Metadata;
using AzaliaJwellery.Commands;
using AzaliaJwellery.Interfaces;
using AzaliaJwellery.Models;
using AzaliaJwellery.Queries;
using AzaliaJwellery.Repositories;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace AzaliaJwellery.Handlers
{
    public class GetAllPaymentHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllPaymentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Payments>> Handle()
        {
            return await _unitOfWork.Payments.GetAllAsync();

        }
    }
}
