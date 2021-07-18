using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreProject.Core.Repositories
{
    public interface IRepository<T> where T : class
    {
        // Asenkron(Task)= senkron(void) anlamına gelir 
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        //find. Linq kullanmak için
        IEnumerable<T> Where(Expression<Func<T, bool>> filter);
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> filter);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        T Update(T entity);
    }
}
