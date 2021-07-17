using AspNetCoreProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreProject.Core.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        //Sadece categorye özgü olan, GenericRepository'de bulunmasını istemediğimiz methotları buraya tanımlarız
        Task<Category> GetWithProductsByIdAsync(int categoryId);
    }
}
