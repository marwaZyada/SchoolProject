using AutoMapper;
using MediatR;
using School.Application.Handlers.CourseHandelers.Dto;
using School.Domain.Repositories.Interfaces.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Handlers.CourseHandelers.Queries.GetById
{
    public class GetByIdCourseQueryHandler : IRequestHandler<GetByIdCourseQuery, CourseDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetByIdCourseQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CourseDto> Handle(GetByIdCourseQuery request, CancellationToken cancellationToken)
        {
          var course=_mapper.Map<CourseDto>( await _unitOfWork.CourseRepository.GetById(request.Id,c=>c.StudentCourses));
           
            return course;
        }
    }
}
