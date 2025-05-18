using AutoMapper;
using School.Application.Handlers.CourseHandelers.Commands_.CreateCourse;
using School.Application.Handlers.CourseHandelers.Dto;
using School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Handlers.CourseHandelers.Mapper
{
    public class CourseMappingProfile:Profile
    {
        public CourseMappingProfile()
        {
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<CreateCourseCommand, Course>();
        }
    }
}
