using AzaliaJwellery.Commands;
using AzaliaJwellery.Interfaces;
using AzaliaJwellery.Models;
using AzaliaJwellery.Repositories;

namespace AzaliaJwellery.Handlers
{
    public class DeleteAddressHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public DeleteAddressHandler( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(DeleteAddressCommand command)
        {
            var address = await _unitOfWork.Addresses.GetByIdAsync(command.Id);
            if (address == null) {
                throw new Exception("Address not found");
            }
            _unitOfWork.Addresses.Remove(address);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
