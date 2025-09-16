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
    internal class StudentConfigurations : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(st => st.FName).HasMaxLength(50);
            builder.Property(st => st.LName).HasMaxLength(50);

            builder.Property(ins => ins.Address)
                      .IsRequired(false)
                      .HasMaxLength(150)
                      .HasDefaultValue("N/F");

            // One(Departments) To Many(Students)
            builder.HasOne(std => std.Department)
                   .WithMany(d => d.Students)
                   .HasForeignKey(std => std.DeptId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .IsRequired();


        }
    }
}
