using AutoMapper;
using MediatR;
using School.Application.Services;
using School.Domain.Repositories.Interfaces.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Handlers.CourseHandelers.Commands_.UpdateCourse
{
    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, string>
    {
        private readonly ICoursService _coursService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCourseCommandHandler(ICoursService coursService, IUnitOfWork unitOfWork,IMapper mapper)
        {
            _coursService = coursService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<string> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var course=await _unitOfWork.CourseRepository.GetById(request.Id);
            if (course == null) return "not found";
            
                var newcourse = _mapper.Map(request, course);
                var result =await _coursService.UpdateCourse(newcourse);
                return $"{result} has been updated";
         
            
        }
    }
}
