using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using KeenSap.Portal.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace KeenSap.Portal.Data.Repository.Contract
{
    public interface IGenericRepository<TEntity> : IRepository where TEntity : IEntity
    {
        ICollection<TEntity> Get();
        Task<ICollection<TEntity>> GetAsync();
        IEnumerable<TEntity> FindBy<TKey>(Expression<Func<TEntity, bool>> predicate, Func<TEntity, TKey> keySelector = null, bool desending = false);
        TEntity FindOne(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>> predicate);
        TEntity Add(TEntity entity);
        TEntity Remove(int id);
        void Update(TEntity entity);
        TEntity Get(object id);

        DbContext GetContext();
    }
}
