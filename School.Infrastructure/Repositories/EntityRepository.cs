using Microsoft.EntityFrameworkCore;
using School.Domain.Entities.Authentication;
using School.Domain.Repositories.Interfaces.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace School.Infrastructure.Repositories
{
    public class EntityRepository<T> : IEntityRepository<T>where T : class
    {
        #region field
        private readonly SchoolDbContext _dbContext;
        #endregion

        #region constructor
        public EntityRepository(SchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region methods
        public async Task<T> Add(T entity)
        {
           await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync() ;
        }

        public async Task<T> Get(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
           return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAll(params Expression<Func<T, object>>[] Includes)
        {
            var Query = _dbContext.Set<T>().AsQueryable();
            foreach (var item in Includes)
            {
              Query= Query.Include(item);
            }
            return await Query.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> GetById(int id,params Expression<Func<T, object>>[] Includes)
        {
            var Query = _dbContext.Set<T>();
            foreach (var item in Includes)
            {
             Query.Include(item);
            }
            return await Query.FindAsync(id);
        }

        public IQueryable<T> GetWithNoTracking()
        {
           return _dbContext.Set<T>();
        }

        public async Task Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}
