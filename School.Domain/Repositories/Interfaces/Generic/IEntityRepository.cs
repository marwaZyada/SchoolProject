using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Repositories.Interfaces.Generic
{
    public interface IEntityRepository<T>:IReadRepository<T>,IWriteRepository<T> where T : class
    {
    }
}
