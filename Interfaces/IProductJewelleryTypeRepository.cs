using System.Net;
using AzaliaJwellery.Models;

namespace AzaliaJwellery.Interfaces
{
    public interface IProductJewelleryTypeRepository
    {
        Task AddAsync(ProductJewelleryType productJewelleryType);
        Task<IEnumerable<ProductJewelleryType>> GetByProductIdAsync(int productId);
        void Remove(IEnumerable<ProductJewelleryType> productJewelleryTypes);

    }
}
