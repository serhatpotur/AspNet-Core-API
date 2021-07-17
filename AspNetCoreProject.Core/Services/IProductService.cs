using AspNetCoreProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreProject.Core.Services
{

    public interface IProductService : IService<Product>
    {
        /* Repository sadece veritabanı ile ilgili işlemleri yapar
           Service ise veritabanı ile ilgili olmaya örneğin product üzerinden hesaplama işlemlerini vs tanımlanacağı yerdir
     */
        Task<Product> GetWithCategoryByIdAsync(int productId);

    }
}
