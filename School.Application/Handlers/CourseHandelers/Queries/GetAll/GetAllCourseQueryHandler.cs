using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Handlers.CourseHandelers.Dto;
using School.Domain.Entities;
using School.Domain.Repositories.Interfaces.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Handlers.CourseHandelers.Queries.GetAll
{
    public class GetAllCourseQueryHandler : IRequestHandler<GetAllCourseQuery, IReadOnlyList<CourseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCourseQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<CourseDto>> Handle(GetAllCourseQuery request, CancellationToken cancellationToken)
        {
            var cources = _mapper.Map<IReadOnlyList<CourseDto>>(await _unitOfWork.CourseRepository.GetAll(c => c.StudentCourses));
            return cources;
        }
    }
}
