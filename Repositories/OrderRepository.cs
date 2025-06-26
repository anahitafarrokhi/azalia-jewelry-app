using AzaliaJwellery.Data;
using AzaliaJwellery.Interfaces;
using AzaliaJwellery.Models;
using Microsoft.EntityFrameworkCore;

namespace AzaliaJwellery.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Orders>> GetAllAsync()
        {
            return await _context.Order.Include(p => p.OrderDetail).ToListAsync();

        }
        public async Task<Orders> GetByIdAsync(int id)
        {
            return await _context.Order.Include(p => p.
            OrderDetail).FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task AddAsync(Orders orders)
        {
            await _context.Order.AddAsync(orders);
        }
        public void Update(Orders orders)
        {
            _context.Order.Update(orders);  
        }
        public void Remove(Orders orders)

        {
            _context.Remove(orders);
        }
        public async Task<bool> AnyAsync(int id)
        {
           return await _context.Order.AnyAsync(p => p.Id == id);
        }

    }
}
