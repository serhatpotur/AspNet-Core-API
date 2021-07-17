using AspNetCoreProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreProject.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        /*UnitOfWork CRUD işlemlerini bizim yapmamızı sağlar
         * Örneğin 10 tane ardarda güncelleme işlemi yapıyoruz ve 4. işlemde hata çıktı.
         * UnitOfWork bu işlemleri bir hafızada tutar ve hata varsa geri alabilme imkanını bize verir
         * Eğer hata yoksa SaveChange veya Commit (methot ismi) diyerek güncelleme işlemini başarılı bir şekilde yapabiliriz
        */

        ICategoryRepository Categories { get; }
        IProductRepository Products { get; }

        //Asenkron olan
        Task CommitAsync();

        //Asenkron Olmayan
        void Commit();
    }
}
