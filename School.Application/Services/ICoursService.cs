using School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Services
{
    public interface ICoursService
    {
        Task<string> DeleteCourse(Course course);
        Task<string> AddCourse(Course course) ;
        Task<string> UpdateCourse(Course course);
    }
}
