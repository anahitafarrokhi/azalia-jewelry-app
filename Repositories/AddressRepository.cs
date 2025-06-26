using AzaliaJwellery.Data;
using AzaliaJwellery.Interfaces;
using AzaliaJwellery.Models;
using Microsoft.EntityFrameworkCore;

namespace AzaliaJwellery.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ApplicationDbContext _context;

        public AddressRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Addresses>> GetByUserIdAsync(int userId)
        {
            return await _context.Addresses.Where(p => p.UserId == userId).ToListAsync();

        }
        public async Task<Addresses> GetByIdAsync(int id)
        {
            return await _context.Addresses.FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task AddAsync(Addresses adresses)
        {
            await _context.Addresses.AddAsync(adresses);
        }
        public void Update(Addresses adresses)
        {
            _context.Addresses.Update(adresses);  
        }
        public void Remove(Addresses adresses)

        {
            _context.Addresses.Remove(adresses);
        }
      

    }
}
