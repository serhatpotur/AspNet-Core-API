using AspNetCoreProject.Core.Entities;
using AspNetCoreProject.Core.Repositories;
using AspNetCoreProject.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreProject.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            // include ile ilgili product'un category'sini de dönmüş oldum
            var product = _appDbContext.Products.Include(x => x.Category).SingleOrDefaultAsync(x => x.ProductID == productId);
            return await product;
        }
    }
}
