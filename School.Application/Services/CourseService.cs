using School.Domain.Entities;
using School.Domain.Repositories.Interfaces.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Services
{
    internal class CourseService : ICoursService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CourseService(IUnitOfWork unitOfWork )
        {
           _unitOfWork = unitOfWork;
        }
        public async Task<string> Coursetitle(Course course)
        {
          await _unitOfWork.CourseRepository.Add(course);
          await  _unitOfWork.SaveChanges();
            return course.Title;
        }
    }
}
