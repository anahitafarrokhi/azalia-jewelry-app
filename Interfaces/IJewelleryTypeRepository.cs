using System.Net;
using AzaliaJwellery.Models;

namespace AzaliaJwellery.Interfaces
{
    public interface IJewelleryTypeRepository
    {
        Task<IEnumerable<JewelleryType>> GetByCategoryIdAsync(int categoryId);
        Task<JewelleryType> GetByIdAsync(int id);
        
        Task AddAsync(JewelleryType JewelleryType);
        void Update(JewelleryType JewelleryType);
        void Remove(JewelleryType JewelleryType);
    }
}
