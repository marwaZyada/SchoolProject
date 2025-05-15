using School.Domain.Entities;
using School.Domain.Repositories.Interfaces.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Repositories.Interfaces.Entities
{
    public interface IInstructorRepository:IEntityRepository<Instructor>
    {
    }
}
