
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
    internal class InstructorConfigurations : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.Property(ins => ins.Name)
                .HasMaxLength(50)
                .HasAnnotation("MinLength", 2)
                .IsRequired();

            builder.Property(ins => ins.Bouns)
                .HasAnnotation("AllowedValues",
                    new object[] { 100, 200, 300, 400, 500 });
            builder.Property(ins => ins.Salary)
                .HasColumnType("Money");
            //.HasColumnType("decimal(10,2)");

            /// builder.Property(ins => ins.Address)
            ///       .IsRequired(false)
            ///       .HasMaxLength(150)
            ///       .HasDefaultValue("N/F")
            ///       ;

            builder.Property(ins => ins.HourRate).IsRequired(false);

            builder.Property(ins => ins.DepartmentId)
                   .IsRequired();

            //Not Valid
            /// builder.HasMany(ins => ins.Courses)
            ///        .WithMany(c => c.Instructors)
            ///        .

        }
    }
}
