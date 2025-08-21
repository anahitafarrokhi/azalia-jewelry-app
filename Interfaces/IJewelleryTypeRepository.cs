using System.Net;
using AzaliaJwellery.Models;

namespace AzaliaJwellery.Interfaces
{
    public interface IJewelleryTypeRepository
    {
        Task<IEnumerable<JewelleryType>> GetAllAsync();
       
        
        Task AddAsync(JewelleryType JewelleryType);
        void Update(JewelleryType JewelleryType);
        void Remove(JewelleryType JewelleryType);
        void RemoveAll(IEnumerable<JewelleryType> JewelleryType);
        
    }
}
