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
    public class GetAllAddressesByUserIdHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllAddressesByUserIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Addresses>> Handle(GetAllAddressesByUserIdQuery query)
        {
            return await _unitOfWork.Addresses.GetByUserIdAsync(query.UserId);

        }
    }
}
