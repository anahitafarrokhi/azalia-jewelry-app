using AzaliaJwellery.Data;
using AzaliaJwellery.Interfaces;
using AzaliaJwellery.Models;
using AzaliaJwellery.Queries;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AzaliaJwellery.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Products>> GetAllAsync()
        {
            return await _context.Products.Include(p => p.ProductCategory).Include(p => p.ProductJewelleryTypes).Include(p => p.Images).ToListAsync();
        }

        public async Task<Products> GetByIdAsync(int id)
        {
            return await _context.Products.Include(p => p.ProductCategory).Include(p => p.ProductJewelleryTypes).ThenInclude(pjt => pjt.JewelleryType).Include(p => p.Images)
                                          .FirstOrDefaultAsync(p => p.Id == id);
        }
        //recent engagmnt rings
        public async Task<List<Products>> GetProductsByCategoryIdAsync(GetProductsByCategoryIdQuery request)
        {

            //کوئری مهم وقتی میحوایم جدول چند به چند را برگردانیم
            //        var products = await _context.Products
            //.Where(product => product.ProductCategoryId == request.CategoryId &&
            //    ((int)product.Color == request.itemColor || request.itemColor == 0) &&
            //    ((int)product.LabOrNat == request.itemLabOrNat || request.itemLabOrNat == 0) &&
            //    ((int)product.Shape == request.itemShape || request.itemShape == 0) &&
            //    ((product.CaratWeight >= request.caratRangeMin || request.caratRangeMin == 0) &&
            //     (product.CaratWeight <= request.caratRangeMax || request.caratRangeMax == 0)) &&
            //    ((product.Price >= request.budgetRangeMin || request.budgetRangeMin == 0) &&
            //     (product.Price <= request.budgetRangeMax || request.budgetRangeMax == 0))
            //)
            //.Include(p => p.ProductCategory)
            //.Include(p => p.Images)
            //.Include(p => p.ProductJewelleryTypes)
            //    .ThenInclude(pjt => pjt.JewelleryType)
            //.OrderByDescending(x => x.CreateDate)
            //.Select(p => new
            //{
            //    Id = p.Id,
            //    Title = p.Title,
            //    Description = p.Description,
            //    ProductCategory = p.ProductCategory.Name,

            //    JewelleryTypes = p.ProductJewelleryTypes.Select(pjt => new
            //    {
            //        pjt.JewelleryType.Id,
            //        pjt.JewelleryType.Name,
            //        pjt.JewelleryType.Desc
            //    }).ToList()
            //})
            //.ToListAsync();
            var query = _context.Products
                  .Where(product => ((int)product.Style == request.selectedStyle || request.selectedStyle == 0) && (request.JewelleryTypeID == 0 || product.ProductJewelleryTypes.Any(z=>z.JewelleryTypeId == request.JewelleryTypeID)  
                  ) 
                  && (product.ProductCategoryId == request.CategoryId || request.CategoryId == 0) && ((int)product.Color == request.itemColor ||
                  request.itemColor == 0) && 
                  ((int)product.LabOrNat == request.itemLabOrNat || request.itemLabOrNat == 0)
                  && ((int)product.Shape == request.itemShape || request.itemShape == 0) && ((product.CaratWeight >= request.CaratRangeMin || request.CaratRangeMin == 0) &&
                  (product.CaratWeight <= request.CaratRangeMax || request.CaratRangeMax == 0))
                  && ((product.Price >= request.BudgetRangeMin || request.BudgetRangeMin == 0) && (product.Price <= request.BudgetRangeMax || request.BudgetRangeMax == 0))

                  && ((request.TitleValue == "Cut" && (int)product.Cut >= request.debouncedMinRangeValue && (int)product.Cut <= request.debouncedMaxRangeValue) ||
                  (request.TitleValue == "Budget Range (AED)" || request.TitleValue == "Carat" || request.TitleValue == "Clarity" || request.TitleValue == "Colour" || request.TitleValue.IsNullOrEmpty()))

                  && ((request.TitleValue == "Clarity" && (int)product.Clarity >= request.debouncedMinRangeValue && (int)product.Clarity <= request.debouncedMaxRangeValue) ||
                  (request.TitleValue == "Cut" || request.TitleValue == "Colour" || request.TitleValue == "Budget Range (AED)" || request.TitleValue == "Carat" || request.TitleValue.IsNullOrEmpty()))

                  && ((request.TitleValue == "Colour" && (int)product.DiamondColor >= request.debouncedMinRangeValue && (int)product.DiamondColor <= request.debouncedMaxRangeValue) ||
                  (request.TitleValue == "Budget Range (AED)" || request.TitleValue == "Carat" || request.TitleValue == "Clarity" || request.TitleValue == "Cut" || request.TitleValue.IsNullOrEmpty()))
                  && (request.itemLabOrNat == (int)product.LabOrNat || request.itemLabOrNat == 0)
                  )
                  .Include(p => p.ProductCategory)
                  .Include(p => p.Images)
                  .Include(p => p.ProductJewelleryTypes) // Include the middle table
                      .ThenInclude(pjt => pjt.JewelleryType);
            if (request.SelectedValue == 1)
            {
                return await query.OrderBy(p => p.Title).ToListAsync();
            }
            else if (request.SelectedValue == 2)
            {
                return await query.OrderByDescending(p => p.Title).ToListAsync();
            }
            else if (request.SelectedValue == 3)
            {
                return await query.OrderBy(p => p.Price).ToListAsync();
            }
            else if (request.SelectedValue == 4)
            {
                return await query.OrderByDescending(p => p.Price).ToListAsync();
            }
            else
            {
                return await query.OrderByDescending(p => p.CreateDate).ToListAsync(); // default
            }

        }

        

        public async Task<List<Products>> GetProductsByCategoryIdExclusiveAsync(int categoryId)
        {
            return await _context.Products
                .Where(product => product.ProductCategoryId == categoryId && product.ProductJewelleryTypes.Any(z => z.JewelleryTypeId == 37)).Include(p => p.ProductCategory)
                .Include(p => p.ProductJewelleryTypes).Include(p => p.Images).OrderByDescending(x => x.CreateDate)
                .ToListAsync();
        }

        public async Task AddAsync(Products products)
        {
            await _context.Products.AddAsync(products);
        }

        public void Update(Products products)
        {
            _context.Products.Update(products);
        }

        public void Remove(Products products)
        {
            _context.Products.Remove(products);
        }
        public async Task<bool> AnyAsync(int id)
        {
            return await _context.Order.AnyAsync(p => p.Id == id);
        }
    }
}