using Livraria.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Persistance
{
    public class Repository<TContext, T> : IRepository<T>
      where T : class
      where TContext : DbContext
    {
        protected TContext _context;
        protected DbSet<T> _dbSet;


        public Repository(TContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        #region Get Records
        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public virtual async Task<ICollection<T>> GetAllAsyn()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual T Get(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual T Get(Guid id)
        {
            return _dbSet.Find(id);
        }

        public virtual async Task<T> GetAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<T> GetAsync(string id)
        {
            return await _dbSet.FindAsync(id);
        }
        #endregion

        #region Insert Records with or without UOW
        public virtual T Add(T t)
        {
            _dbSet.Add(t);
            _context.SaveChanges();
            return t;
        }

        public virtual List<T> AddRange(List<T> t)
        {
            _dbSet.AddRange(t);
            _context.SaveChanges();
            return t;
        }


        public virtual void AddUncommited(T t)
        {
            _dbSet.Add(t);
        }

        public virtual async Task<T> AddAsyn(T t)
        {
            _dbSet.Add(t);
            await _context.SaveChangesAsync();
            return t;

        }

        public virtual async Task AddUncommitedAsyn(T t)
        {
            await _dbSet.AddAsync(t);
        }
        #endregion

        #region Find Records or First record
        public T FindFirst(Expression<Func<T, bool>> filter, params Expression<Func<T, bool>>[] includes)
        {
            IQueryable<T> query = _dbSet;
            query = includes.Aggregate(query, (current, include) => current.Include(include));

            return query.SingleOrDefault(filter);
        }

        public virtual async Task<T> FindFirstAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;
            query = includes.Aggregate(query, (current, include) => current.Include(include));

            return await query.SingleOrDefaultAsync(filter);
        }
        public ICollection<T> FindAll(Expression<Func<T, bool>> match)
        {
            return _dbSet.Where(match).ToList();
        }

        public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match)
        {
            return await _dbSet.Where(match).ToListAsync();
        }
        #endregion

        #region Delete Records
        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public virtual void DeleteRange(List<T> entity)
        {
            _dbSet.RemoveRange(entity);
            _context.SaveChanges();
        }

        public virtual void DeleteUnCommited(T entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual async Task<int> DeleteAsyn(T entity)
        {
            _dbSet.Remove(entity);
            return await _context.SaveChangesAsync();
        }
        #endregion

        #region Update
        public virtual T Update(T t, object key)
        {
            if (t == null)
                return null;
            T exist = _dbSet.Find(key);
            if (exist != null)
            {
                _context.Entry(exist).CurrentValues.SetValues(t);
                _context.SaveChanges();
            }
            return exist;
        }

        public virtual void UpdateUncommited(T t, object key)
        {
            if (t == null)
                return;
            T exist = _dbSet.Find(key);
            if (exist != null)
            {
                _context.Entry(exist).CurrentValues.SetValues(t);
            }
        }

        public virtual async Task<T> UpdateAsyn(T t, object key)
        {
            if (t == null)
                return null;
            T exist = await _dbSet.FindAsync(key);
            if (exist != null)
            {
                _context.Entry(exist).CurrentValues.SetValues(t);
                await _context.SaveChangesAsync();
            }
            return exist;
        }

        public virtual async Task UpdateUnCommitedAsyn(T t, object key)
        {
            if (t == null)
                return;
            T exist = await _dbSet.FindAsync(key);
            if (exist != null)
            {
                _context.Entry(exist).CurrentValues.SetValues(t);
            }
        }

        #endregion

        #region Find Records with Conditions
        public List<T> GetWithFilterAndInclude(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;
            query = includes.Aggregate(query, (current, include) => current.Include(include));

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return query.AsNoTracking().ToList();
        }

        public int Count()
        {
            return _dbSet.Count();
        }

        public async Task<int> CountAsync()
        {
            return await _dbSet.CountAsync();
        }
        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _dbSet.Where(predicate);
            return query.AsNoTracking();
        }

        public virtual async Task<ICollection<T>> FindByAsyn(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).AsNoTracking().ToListAsync();
        }

        public IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = GetAll();
            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {
                queryable = queryable.Include<T, object>(includeProperty);
            }

            return queryable.AsNoTracking();
        }

        public void AddUnCommited(T t)
        {
            throw new NotImplementedException();
        }

        public void AddUnCommitedAsync(T t)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
