using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ISCS.Data.Entities;

namespace ISCS.Data.Infrastucture.Interfaces
{
    public interface IGenericRepository<TEntity>
    where TEntity : class
    {
        TEntity Create(TEntity entity);

        void Remove(TEntity item);

        void Update(TEntity item);

        TEntity FindById(long id);

        IEnumerable<TEntity> Get();

        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);

        IEnumerable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties);

        IEnumerable<TEntity> GetWithInclude(Func<TEntity, bool> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties);
    }
}
