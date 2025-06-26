using AzaliaJwellery.Models;

namespace AzaliaJwellery.Interfaces
{
    public interface IOrderRepository

    {
        Task<IEnumerable<Orders>> GetAllAsync();
        Task<Orders> GetByIdAsync(int id);
        Task AddAsync(Orders orders);
        void Update(Orders orders);
        void Remove(Orders orders);
        Task<bool> AnyAsync(int id);

    }
}
