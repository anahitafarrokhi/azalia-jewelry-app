using AzaliaJwellery.Interfaces;
using AzaliaJwellery.Models;
using AzaliaJwellery.Queries;

namespace AzaliaJwellery.Handlers
{
    public class GetPaymentByIdHandler
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPaymentByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

       public async Task<Payments> Handle(GetPaymentByIdQuery query)
        {
            return await _unitOfWork.Payments.GetByIdAsync(query.Id);

        }
    }
}
