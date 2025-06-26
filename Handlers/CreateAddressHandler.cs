using AzaliaJwellery.Commands;
using AzaliaJwellery.Interfaces;
using AzaliaJwellery.Models;
using AzaliaJwellery.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AzaliaJwellery.Handlers
{
    public class CreateAddressHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateAddressHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(CreateAddressCommand command)
        {
            var address = new Addresses()
            {
                FullName = command.FullName,
                AddresseLine1 = command.AddresseLine1,
                AddresseLine2 = command.AddresseLine2,
                City = command.City,
                State = command.State,
                PostalCode = command.PostalCode,
                Country = command.Country,
                IsDefault = command.IsDefault,
                UserId = command.UserId

            };
            await _unitOfWork.Addresses.AddAsync(address);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
