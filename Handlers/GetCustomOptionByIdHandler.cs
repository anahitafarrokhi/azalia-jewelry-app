using AzaliaJwellery.Interfaces;
using AzaliaJwellery.Models;
using AzaliaJwellery.Queries;

namespace AzaliaJwellery.Handlers
{
    public class GetCustomOptionByIdHandler
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCustomOptionByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

       public async Task<CustomizationOption> Handle(GetCustomOptionsByIdQuery query)
        {
            return await _unitOfWork.CustomOption.GetByIdAsync(query.Id);

        }
    }
}
