using AspNetCoreProject.Core.Repositories;
using AspNetCoreProject.Core.Services;
using AspNetCoreProject.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreProject.Service.Services
{
    public class Service<T> : IService<T> where T : class
    {
        public readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<T> _repository;
        public Service(IUnitOfWork unitOfWork, IRepository<T> repository)
        {
            _unitOfWork = unitOfWork; //veri tabanına kayıt için 
            _repository = repository; //repository içinde ki hazır methotları erişim için
        }
        public async Task<T> AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            return entities;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public void Remove(T entity)
        {
            _repository.Remove(entity);
            _unitOfWork.Commit();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _repository.RemoveRange(entities);
            _unitOfWork.Commit();
        }

        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> filter)
        {
            return await _repository.SingleOrDefaultAsync(filter);
        }

        public T Update(T entity)
        {
            T updateEntity = _repository.Update(entity);
            _unitOfWork.Commit();
            return updateEntity;
        }

        public async Task<IEnumerable<T>> Where(Expression<Func<T, bool>> filter)
        {
            return await _repository.Where(filter);
        }
    }
}
