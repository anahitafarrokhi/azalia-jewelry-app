using AzaliaJwellery.Interfaces;
using AzaliaJwellery.Models;
using AzaliaJwellery.Queries;

namespace AzaliaJwellery.Handlers
{
    public class GetAddressByIdHandler
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAddressByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

       public async Task<Addresses> Handle(GetAddressByIdQuery query)
        {
            return await _unitOfWork.Addresses.GetByIdAsync(query.Id);

        }
    }
}
