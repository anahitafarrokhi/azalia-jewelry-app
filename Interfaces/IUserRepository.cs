using AzaliaJwellery.Models;

namespace AzaliaJwellery.Interfaces
{
    public interface IUserRepository

    {
        Task<IEnumerable<Users>> GetAllAsync();
        Task<Users> GetByIdAsync(int id);
        Task AddAsync(Users orders);
        void Update(Users orders);
        void Remove(Users orders);
        Task<bool> AnyAsync(int id);

    }
}
