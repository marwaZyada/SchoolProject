using FluentValidation;
using MediatR;
using School.Application.Handlers.CourseHandelers.Dto;
using School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Handlers.CourseHandelers.Commands_.CreateCourse
{
   public class CreateCourseValidator:AbstractValidator<CreateCourseCommand>
    {
        public CreateCourseValidator()
        {
            ApplyRules();
        }
        public void ApplyRules()
        {
            RuleFor(c => c.Title).NotNull().WithMessage("Course Title Can't be null");
            RuleFor(c => c.Title).MinimumLength(3).WithMessage("Course title length can't be less than 3 character");
        }
    }
}
