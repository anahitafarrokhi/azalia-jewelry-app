using System.Net;
using AzaliaJwellery.Models;

namespace AzaliaJwellery.Interfaces
{
    public interface IImagesRepository
    {
        Task<IEnumerable<Images>> GetByProductIdAsync(int productId);
        void Remove(IEnumerable<Images> Images);


    }
}
