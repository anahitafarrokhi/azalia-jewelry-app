using System.Linq.Expressions;
using AzaliaJwellery.Models;
using AzaliaJwellery.Queries;

namespace AzaliaJwellery.Interfaces
{
    public interface IProductRepository 
    {
        Task<IEnumerable<Products>> GetAllAsync();
        Task<Products> GetByIdAsync(int id);
        Task AddAsync(Products product);
        void Update(Products product);
        void Remove(Products product);
        Task<bool> AnyAsync(int id);
        Task<List<Products>> GetProductsByCategoryIdAsync(GetProductsByCategoryIdQuery request);
        Task<List<Products>> GetProductsByCategoryIdExclusiveAsync(int categoryId);
    }
}

