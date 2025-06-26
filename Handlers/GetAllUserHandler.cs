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
    public class GetAllUserHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Users>> Handle()
        {
            return await _unitOfWork.Users.GetAllAsync();

        }
    }
}
