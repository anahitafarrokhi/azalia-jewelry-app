using AzaliaJwellery.Data;
using AzaliaJwellery.Interfaces;
using AzaliaJwellery.Models;
using Microsoft.EntityFrameworkCore;

namespace AzaliaJwellery.Repositories
{
    public class JewelleryTypeRepository : IJewelleryTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public JewelleryTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<JewelleryType>> GetByCategoryIdAsync(int categoryId)
        {
            return await _context.JewelleryType.Where(jt => jt.ProductJewelleryTypes.Any(pjt => pjt.Product.ProductCategoryId == categoryId)).ToListAsync();
        }
        public async Task<JewelleryType> GetByIdAsync(int id)
        {
            return await _context.JewelleryType.FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task AddAsync(JewelleryType jewelleryType)
        {
            await _context.JewelleryType.AddAsync(jewelleryType);
        }
        public void Update(JewelleryType jewelleryType)
        {
            _context.JewelleryType.Update(jewelleryType);
        }
        public void Remove(JewelleryType jewelleryType)

        {
            _context.JewelleryType.Remove(jewelleryType);
        }


    }
}
