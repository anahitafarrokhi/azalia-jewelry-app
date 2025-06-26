using System.Net;
using AzaliaJwellery.Models;

namespace AzaliaJwellery.Interfaces
{
    public interface IProductJewelleryTypeRepository
    {
        Task AddAsync(ProductJewelleryType ProductJewelleryType);


    }
}
