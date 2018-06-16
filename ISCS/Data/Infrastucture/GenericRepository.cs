using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ISCS.Data.Infrastucture.Interfaces;
using ISCS.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ISCS.Data.Infrastucture
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
    where TEntity : class
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public TEntity Create(TEntity item)
        {
            var res = _dbSet.Add(item);
            return res.Entity;
        }

        public void Remove(TEntity item)
        {
            _dbSet.Remove(item);
        }

        public void Remove(Func<TEntity, bool> predicate)
        {
            _dbSet.RemoveRange(_dbSet.Where(predicate));
        }

        public void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public TEntity FindById(long id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<TEntity> Get()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public IEnumerable<TEntity> GetAsTracking(Func<TEntity, bool> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public IEnumerable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return _dbSet.Include(false, includeProperties).ToList();
        }

        public IEnumerable<TEntity> GetWithInclude(Func<TEntity, bool> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return _dbSet.Include(false, includeProperties).Where(predicate).ToList();
        }

        public long Max(Func<TEntity, long> selector)
        {
            return _dbSet.Max(selector);
        }
    }
}
