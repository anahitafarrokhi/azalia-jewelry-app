using System.Net;
using AzaliaJwellery.Models;

namespace AzaliaJwellery.Interfaces
{
    public interface IAddressRepository
    {
        Task<IEnumerable<Addresses>> GetByUserIdAsync(int userId);
        Task<Addresses> GetByIdAsync(int id);
        
        Task AddAsync(Addresses Address);
        void Update(Addresses Address);
        void Remove(Addresses Address);
    }
}
