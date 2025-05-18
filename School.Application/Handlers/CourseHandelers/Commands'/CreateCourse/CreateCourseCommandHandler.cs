using AutoMapper;
using MediatR;
using School.Application.Handlers.CourseHandelers.Dto;
using School.Application.Services;
using School.Domain.Entities;
using School.Domain.Repositories.Interfaces.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Handlers.CourseHandelers.Commands_.CreateCourse
{
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, string>
    {
        
        private readonly ICoursService _coursService;
        private readonly IMapper _mapper;

        public CreateCourseCommandHandler(ICoursService coursService,IMapper mapper)
        {
         
            _coursService = coursService;
            _mapper = mapper;
        }
        public async Task<string> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = _mapper.Map<Course>(request);
            var title =await _coursService.Coursetitle(course);
            return title;
        }
    }
}
