using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Handlers.CourseHandelers.Commands_.UpdateCourse
{
    public class UpdateCourseCommandValidator:AbstractValidator<UpdateCourseCommand>
    {
        public UpdateCourseCommandValidator()
        {
            RuleFor(c => c.Title).NotEmpty().NotNull().WithMessage("Course Title Can't be null");
            RuleFor(c => c.Title).MinimumLength(3).WithMessage("Course title length can't be less than 3 character");
        }
    }
}
