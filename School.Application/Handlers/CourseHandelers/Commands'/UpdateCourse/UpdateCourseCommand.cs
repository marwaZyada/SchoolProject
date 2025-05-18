using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Handlers.CourseHandelers.Commands_.UpdateCourse
{
    public class UpdateCourseCommand:IRequest<string>
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
