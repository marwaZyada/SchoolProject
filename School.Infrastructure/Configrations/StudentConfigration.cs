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
    public class StudentConfigration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");
            builder.HasOne(i => i.Instructor)
             .WithMany();
            builder.HasData(new Student { Id = 1, FullName = "Hala", InstructorId = 1 },
                new Student { Id = 2, FullName = "Hana", InstructorId = 2 },
                new Student { Id = 3, FullName = "Hanaa", InstructorId = 3 });

        }
    }
}
