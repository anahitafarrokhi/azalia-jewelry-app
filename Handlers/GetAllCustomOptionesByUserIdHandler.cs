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
    public class GetAllCustomOptionesByUserIdHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllCustomOptionesByUserIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<CustomizationOption>> Handle(GetAllCustomOptionsByProductIdQuery query)
        {
            return await _unitOfWork.CustomOption.GetByProductIdAsync(query.ProductId);

        }
    }
}
