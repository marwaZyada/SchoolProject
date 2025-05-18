using MediatR;
using School.Application.Handlers.CourseHandelers.Dto;
using School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Handlers.CourseHandelers.Queries.GetAll
{
    public class GetAllCourseQuery:IRequest<IReadOnlyList<CourseDto>>
    {
    }
}
