using Demo.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Configurations
{
    public class CourseInstructorConfiguration : IEntityTypeConfiguration<CourseInstructor>
    {
        public void Configure(EntityTypeBuilder<CourseInstructor> builder)
        {
            builder.HasKey(c => new { c.CourseId, c.InstructorId });

            builder.HasOne(CI => CI.Instructor)
                   .WithMany(ins => ins.CourseInstructors)
                   .HasForeignKey(CI => CI.InstructorId)
                   .IsRequired()
                   ;

            builder.HasOne(CI => CI.Course)
                   .WithMany(c => c.CourseInstructors)
                   .HasForeignKey(CI => CI.CourseId)
                   .IsRequired()
                   ;
        }
    }
}
