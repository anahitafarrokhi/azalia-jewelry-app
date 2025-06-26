using System.Net;
using AzaliaJwellery.Models;

namespace AzaliaJwellery.Interfaces
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<Payments>> GetAllAsync();
        Task<Payments> GetByIdAsync(int id);
        
        Task AddAsync(Payments Payment);
        void Update(Payments Payment);
        void Remove(Payments Payment);
    }
}
