using AzaliaJwellery.Data;
using AzaliaJwellery.Interfaces;
using System;
using System.Collections.Specialized;

namespace AzaliaJwellery.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IProductRepository Products { get; }
        public IOrderRepository Orders { get; }
        public IUserRepository Users { get; }
        public IAddressRepository Addresses { get; }
        public ICustomOptionRepository CustomOption { get; }
        public IPaymentRepository Payments { get; }
        public IImagesRepository Images { get; }
        public IProductJewelleryTypeRepository ProductJewelleryType { get; }
        public IJewelleryTypeRepository JewelleryType { get; }


        public UnitOfWork(ApplicationDbContext context, IProductRepository productRepository, IOrderRepository orderRepository, IUserRepository users, IAddressRepository addresses,
            ICustomOptionRepository customOptionRepository, IPaymentRepository payments, IImagesRepository images,IProductJewelleryTypeRepository productJewelleryTypeRepository, IJewelleryTypeRepository jewelleryType)
        {
            _context = context;
            Products = productRepository;
            Orders = orderRepository;
            Users = users;
            Addresses = addresses;
            CustomOption = customOptionRepository;
            Payments = payments;
            Images = images;
            ProductJewelleryType = productJewelleryTypeRepository;
            JewelleryType = jewelleryType;
        }

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            
            {
                // Log the full exception details to the console (or use a logger like Serilog, NLog, etc.)
                Console.WriteLine("❌ Error in SaveChangesAsync:");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);

                if (ex.InnerException != null)
                {
                    Console.WriteLine("👉 Inner Exception:");
                    Console.WriteLine(ex.InnerException.Message);
                    Console.WriteLine(ex.InnerException.StackTrace);
                }

                // Optionally rethrow for further inspection upstream
                throw;
            }
        }
    }
}
