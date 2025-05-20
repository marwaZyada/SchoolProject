using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Repositories.Interfaces.Generic
{
   public interface IReadRepository< T> where T : class
    {
       Task< IReadOnlyList<T>> GetAll();
       Task< T> GetById(int id);
        Task<T> Get(Expression<Func<T, bool>> predicate) ;
        Task<IReadOnlyList<T>> GetAll(params Expression<Func<T,object>>[] Includes);
       IQueryable<T> GetWithNoTracking();   
        Task<T> GetById(int id,params Expression<Func<T, object>>[] Includes);
    }
}
