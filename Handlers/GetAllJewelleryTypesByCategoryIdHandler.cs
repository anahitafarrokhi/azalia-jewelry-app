using System.Reflection.Metadata;
using AzaliaJwellery.Commands;
using AzaliaJwellery.Interfaces;
using AzaliaJwellery.Models;
using AzaliaJwellery.Queries;
using AzaliaJwellery.Repositories;
using MediatR;

namespace AzaliaJwellery.Handlers
{
    public class GetAllJewelleryTypesByCategoryIdHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllJewelleryTypesByCategoryIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<JewelleryType>> Handle(GetAllJewelleryTypeByCategoryIdQuery query)
        {
            return await _unitOfWork.JewelleryType.GetByCategoryIdAsync(query.CategoryId);

        }
    }
}
