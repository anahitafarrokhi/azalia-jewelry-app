using AzaliaJwellery.Commands;
using AzaliaJwellery.Interfaces;
using AzaliaJwellery.Models;
using AzaliaJwellery.Repositories;

namespace AzaliaJwellery.Handlers
{
    public class DeleteCustomOptionHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public DeleteCustomOptionHandler( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(DeleteCustomOptionCommand command)
        {
            var customOption = await _unitOfWork.CustomOption.GetByIdDeletableAsync(command.Id);
            if (customOption == null) {
                throw new Exception("Address not found");
            }
            _unitOfWork.CustomOption.Remove(customOption);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
