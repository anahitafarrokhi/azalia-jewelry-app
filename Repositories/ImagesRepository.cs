using AzaliaJwellery.Data;
using AzaliaJwellery.Interfaces;
using AzaliaJwellery.Models;
using Microsoft.EntityFrameworkCore;

namespace AzaliaJwellery.Repositories
{
    public class ImagesRepository : IImagesRepository
    {
        private readonly ApplicationDbContext _context;

        public ImagesRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Images>> GetByProductIdAsync(int productId)
        {
            return await _context.Images.Where(p => p.ProductsId == productId).ToListAsync();

        }
        public async Task AddAsync(List<Images> images)
        {
            foreach (var image in images)
            {
                await _context.Images.AddAsync(image);
            }
        }

        public void Remove(IEnumerable<Images> Images)
        {
            _context.Images.RemoveRange(Images);
        }

    }
}
