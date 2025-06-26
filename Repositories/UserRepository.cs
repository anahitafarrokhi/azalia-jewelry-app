using AzaliaJwellery.Data;
using AzaliaJwellery.Interfaces;
using AzaliaJwellery.Models;
using Microsoft.EntityFrameworkCore;

namespace AzaliaJwellery.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Users>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();

        }
        public async Task<Users> GetByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task AddAsync(Users users)
        {
            await _context.Users.AddAsync(users);
        }
        public void Update(Users users)
        {
            _context.Users.Update(users);  
        }
        public void Remove(Users users)

        {
            _context.Remove(users);
        }
        public async Task<bool> AnyAsync(int id)
        {
           return await _context.Users.AnyAsync(p => p.Id == id);
        }

    }
}
