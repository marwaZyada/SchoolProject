using School.Domain.Entities;
using School.Domain.Repositories.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Infrastructure.Repositories
{
    public class StudentRepository : EntityRepository<Student>,IStudentRepository
    {

        #region field
        private readonly SchoolDbContext _dbContext;
        #endregion

        #region constructor
        public StudentRepository(SchoolDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion
       
    }
}
