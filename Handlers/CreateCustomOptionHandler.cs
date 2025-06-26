using System.ComponentModel.DataAnnotations;
using AzaliaJwellery.Commands;
using AzaliaJwellery.Interfaces;
using AzaliaJwellery.Models;
using AzaliaJwellery.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AzaliaJwellery.Handlers
{
    public class CreateCustomOptionHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateCustomOptionHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(CreateCustomOptionCommand command)
        {
            var customizationOption = new CustomizationOption()
            {
                OptionName = command.OptionName,
                OptionValue = command.OptionValue,
                ProductsId = command.ProductsId,

    };
            await _unitOfWork.CustomOption.AddAsync(customizationOption);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
