using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Repositories.Interfaces.Generic
{
   public interface IReadRepository< T> where T : class
    {
       Task< IEnumerable<T>> GetAll();
       Task< T> GetById(int id);
    }
}
