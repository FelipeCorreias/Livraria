using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Livraria.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T Add(T t);
        Task<T> AddAsyn(T t);
        List<T> AddRange(List<T> t);
        void AddUncommited(T t);
        void AddUnCommited(T t);
        Task AddUncommitedAsyn(T t);
        void AddUnCommitedAsync(T t);
        int Count();
        Task<int> CountAsync();
        void Delete(T entity);
        Task<int> DeleteAsyn(T entity);
        void DeleteRange(List<T> entity);
        void DeleteUnCommited(T entity);
        ICollection<T> FindAll(Expression<Func<T, bool>> match);
        Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        Task<ICollection<T>> FindByAsyn(Expression<Func<T, bool>> predicate);
        T FindFirst(Expression<Func<T, bool>> filter, params Expression<Func<T, bool>>[] includes);
        Task<T> FindFirstAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes);
        T Get(Guid id);
        T Get(int id);
        IQueryable<T> GetAll();
        Task<ICollection<T>> GetAllAsyn();
        IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetAsync(int id);
        Task<T> GetAsync(string id);
        List<T> GetWithFilterAndInclude(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes);
        T Update(T t, object key);
        Task<T> UpdateAsyn(T t, object key);
        void UpdateUncommited(T t, object key);
        Task UpdateUnCommitedAsyn(T t, object key);
    }
}