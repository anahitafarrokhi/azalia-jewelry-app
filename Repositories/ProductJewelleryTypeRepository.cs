﻿using AzaliaJwellery.Data;
using AzaliaJwellery.Interfaces;
using AzaliaJwellery.Models;
using Microsoft.EntityFrameworkCore;

namespace AzaliaJwellery.Repositories
{
    public class ProductJewelleryTypeRepository : IProductJewelleryTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductJewelleryTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(ProductJewelleryType ProductJewelleryType)
        {
            await _context.ProductJewelleryType.AddAsync(ProductJewelleryType);
        }
       

    }
}
