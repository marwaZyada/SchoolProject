using MediatR;
using School.Application.Handlers.CourseHandelers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Handlers.CourseHandelers.Queries.GetById
{
   public class GetByIdCourseQuery:IRequest<CourseDto>
    {
        public int Id { get; set; }
    }
}
