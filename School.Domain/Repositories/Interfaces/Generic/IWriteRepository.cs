using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Repositories.Interfaces.Generic
{
    public interface IWriteRepository< T> where T : class
    {
        Task<T> Add(T entity );
        Task Update(T entity);
        Task Delete(T entity);
    }
}
