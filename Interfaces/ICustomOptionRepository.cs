using System.Net;
using AzaliaJwellery.Models;

namespace AzaliaJwellery.Interfaces
{
    public interface ICustomOptionRepository
    {
        Task<IEnumerable<CustomizationOption>> GetByProductIdAsync(int productId);
        Task<CustomizationOption> GetByIdAsync(int id);
        Task<CustomizationOption> GetByIdDeletableAsync(int id);
        

        Task AddAsync(CustomizationOption CustomizationOptions);
        void Update(CustomizationOption CustomizationOption);
        void Remove(CustomizationOption CustomizationOption);
    }
}
