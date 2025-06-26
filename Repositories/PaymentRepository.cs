using AzaliaJwellery.Data;
using AzaliaJwellery.Interfaces;
using AzaliaJwellery.Models;
using Microsoft.EntityFrameworkCore;

namespace AzaliaJwellery.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationDbContext _context;

        public PaymentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Payments>> GetAllAsync()
        {
            return await _context.Payments.ToListAsync();

        }
        public async Task<Payments> GetByIdAsync(int id)
        {
            return await _context.Payments.FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task AddAsync(Payments payment)
        {
            await _context.Payments.AddAsync(payment);
        }
        public void Update(Payments payment)
        {
            _context.Payments.Update(payment);  
        }
        public void Remove(Payments payment)

        {
            _context.Payments.Remove(payment);
        }
      

    }
}
