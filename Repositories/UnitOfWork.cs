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
            return await _context.SaveChangesAsync();
        }
    }
}
