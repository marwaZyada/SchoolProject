using School.Domain.Repositories.Interfaces.Entities;
using School.Domain.Repositories.Interfaces.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        #region field
        private readonly SchoolDbContext _dbContext;
        #endregion

        #region constructor
        public UnitOfWork(SchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion
        public IInstructorRepository InstructorRepository =>new InstructorRepository(_dbContext);

        public IStudentRepository StudentRepository =>  new StudentRepository(_dbContext);

        public ICourseRepository CourseRepository =>new CourseRepository(_dbContext);

        public void Dispose()
        {
           _dbContext.Dispose();
        }

        public async Task<int> SaveChanges()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
