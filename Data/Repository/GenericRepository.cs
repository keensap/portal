using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using KeenSap.Portal.Data.Entities;
using KeenSap.Portal.Data.Repository.Contract;
using Microsoft.EntityFrameworkCore;

namespace KeenSap.Portal.Data.Repository
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : Entity
    {
        private readonly DbContext _context;
        private DbSet<T> _dbset;

        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbset = context.Set<T>();
        }

        public DbContext GetContext() => _context;

        public DbSet<T> Dbset => _dbset;

        public T Add(T entity) => _dbset.Add(entity).Entity;

        public void Update(T entity) => _context.Entry(entity).State = EntityState.Modified;


        public IEnumerable<T> FindBy<TKey>(Expression<Func<T, bool>> predicate, Func<T, TKey> keySelector = null, bool desending = false) 
        {
            var query = _dbset.Where(predicate);
            IEnumerable<T> enumerable;
            if(keySelector == null)
            {
                if(desending)
                {
                    enumerable = query.OrderByDescending(keySelector).AsEnumerable();
                }
                else 
                {
                    enumerable = query.OrderBy(keySelector).AsEnumerable();
                }
            }
            else 
            {
                enumerable = query.AsEnumerable();
            }
            return enumerable;
        }

        public T FindOne(Expression<Func<T, bool>> predicate) => _dbset.Where(predicate).SingleOrDefault();

        public async Task<T> FindOneAsync(Expression<Func<T, bool>> predicate) => await _dbset.Where(predicate).SingleOrDefaultAsync();

        public ICollection<T> Get() => _dbset.ToList();

        public async Task<ICollection<T>> GetAsync() => await _dbset.ToListAsync();

        public T Get(object id) => _dbset.Find(id);

        public T Remove(int id)
        {
            T entity = _dbset.Find(id);
			return _dbset.Remove(entity).Entity;
        }
    }
}
