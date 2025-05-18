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

        public async Task<string> AddCourse(Course course)
        {
            await _unitOfWork.CourseRepository.Add(course);
            await _unitOfWork.SaveChanges();
            return course.Title;
        }


        public async Task<string> DeleteCourse(Course course)
        {
            await _unitOfWork.CourseRepository.Delete(course);
            await _unitOfWork.SaveChanges();
            return course.Title;
        }

        public async Task<string> UpdateCourse(Course course)
        {
            await _unitOfWork.CourseRepository.Update(course);
            await _unitOfWork.SaveChanges();
            return course.Title;
        }
    }
}
