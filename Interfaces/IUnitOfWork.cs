using AzaliaJwellery.Repositories;

namespace AzaliaJwellery.Interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        IOrderRepository Orders { get; }
        IUserRepository Users { get; }
        IAddressRepository Addresses { get; }
        ICustomOptionRepository CustomOption { get; }
        IPaymentRepository Payments{ get; }
        IImagesRepository Images { get; }
        IProductJewelleryTypeRepository ProductJewelleryType { get; }
        IJewelleryTypeRepository JewelleryType { get; }
        
        Task<int> SaveChangesAsync();
    }
}
