using AzaliaJwellery.Interfaces;
using AzaliaJwellery.Models;
using AzaliaJwellery.Queries;

namespace AzaliaJwellery.Handlers
{
    public class GetUserByIdHandler
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUserByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

       public async Task<Users> Handle(GetUserByIdQuery query)
        {
            return await _unitOfWork.Users.GetByIdAsync(query.Id);

        }
    }
}
