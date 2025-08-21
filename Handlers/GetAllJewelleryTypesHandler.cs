using System.Reflection.Metadata;
using AzaliaJwellery.Commands;
using AzaliaJwellery.Interfaces;
using AzaliaJwellery.Models;
using AzaliaJwellery.Queries;
using AzaliaJwellery.Repositories;
using MediatR;

namespace AzaliaJwellery.Handlers
{
    public class GetAllJewelleryTypesHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllJewelleryTypesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<JewelleryType>> Handle()
        {
            return await _unitOfWork.JewelleryType.GetAllAsync();

        }
    }
}
