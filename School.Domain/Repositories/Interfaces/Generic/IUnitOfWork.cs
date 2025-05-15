using School.Domain.Repositories.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Repositories.Interfaces.Generic
{
    public interface IUnitOfWork:IDisposable
    {
        IInstructorRepository InstructorRepository { get; }
        IStudentRepository StudentRepository { get; }
        ICourseRepository CourseRepository { get; }
        Task<int> SaveChanges();
    }
}
