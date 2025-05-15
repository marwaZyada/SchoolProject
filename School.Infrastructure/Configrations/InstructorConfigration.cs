using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Infrastructure.Configrations
{
    public class InstructorConfigration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.ToTable("Instructors");
            builder.HasOne(i => i.Course).WithOne();

            builder.HasData(new Instructor { Id=1,FullName="Saga",CourseId=1},
                new Instructor { Id = 2, FullName = "Sara", CourseId = 2 },
                new Instructor { Id = 3, FullName = "Sama", CourseId = 3 });
        }
    }
}
