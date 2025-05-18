using MediatR;
using School.Application.Services;
using School.Domain.Repositories.Interfaces.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Handlers.CourseHandelers.Commands_.DeleteCourse
{
    public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, string>
    {
        private readonly ICoursService _coursService;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCourseCommandHandler(ICoursService coursService, IUnitOfWork unitOfWork)
        {
            _coursService = coursService;
            _unitOfWork = unitOfWork;
        }
        public async Task<string> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {

            var course = await _unitOfWork.CourseRepository.GetById(request.id);
            if (course is null) return "not found";
            var result = await _coursService.DeleteCourse(course);
            return $"{result} Course is deleted";
        }
    }
}
