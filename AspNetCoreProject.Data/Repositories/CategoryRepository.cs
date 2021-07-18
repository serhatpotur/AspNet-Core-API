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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }

        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Category> GetWithProductsByIdAsync(int categoryId)
        {
            var category = _appDbContext.Categories.Include(x => x.Products).SingleOrDefaultAsync(x => x.CategoryID == categoryId);
            return await category;
        }
    }
}
