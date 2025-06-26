using AzaliaJwellery.Data;
using AzaliaJwellery.Interfaces;
using AzaliaJwellery.Models;
using Microsoft.EntityFrameworkCore;

namespace AzaliaJwellery.Repositories
{
    public class CustomOptionRepository : ICustomOptionRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomOptionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CustomizationOption>> GetByProductIdAsync(int ProductId)
        {
            return await _context.CustomizationOption.Where(p => p.ProductsId == ProductId).ToListAsync();

        }
        public async Task<CustomizationOption> GetByIdAsync(int id)
        {
            return await _context.CustomizationOption.FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<CustomizationOption> GetByIdDeletableAsync(int id)
        {
            return await _context.CustomizationOption.FirstOrDefaultAsync(p => p.Id == id && p.Deletable);
        }
        public async Task AddAsync(CustomizationOption customizationOption)
        {
            await _context.CustomizationOption.AddAsync(customizationOption);
        }
        public void Update(CustomizationOption customizationOption)
        {
            _context.CustomizationOption.Update(customizationOption);  
        }
        public void Remove(CustomizationOption customizationOption)

        {
            _context.CustomizationOption.Remove(customizationOption);
        }
      

    }
}
