using MediatR;
using School.Application.Handlers.CourseHandelers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Handlers.CourseHandelers.Commands_.CreateCourse
{
    public class CreateCourseCommand: IRequest<string>
    {
      
        public string Title { get; set; }
    }
}
