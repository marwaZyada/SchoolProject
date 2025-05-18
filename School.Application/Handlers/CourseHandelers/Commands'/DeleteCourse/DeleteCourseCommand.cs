using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Handlers.CourseHandelers.Commands_.DeleteCourse
{
    public class DeleteCourseCommand:IRequest<string>
    {
        public int id { get; set; }
    }
}
