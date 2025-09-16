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
    internal class DepartmnetConfigurations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Id).UseIdentityColumn(10, 10);

            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);

            builder.Property(p => p.HiringDate)
                .HasAnnotation("DataType", "DataOnly")
                .HasDefaultValueSql("GETDATE()")
                ;

            // One(Department) To Many(Instructors)
            builder.HasMany(d => d.Instructors)
                   .WithOne(ins => ins.Department)
                   .HasForeignKey(ins => ins.DepartmentId)
                   .IsRequired();

            // One(Department) _Mandatory To One(InsManager) _Optional
            builder.HasOne(d => d.InsManager)
                   .WithOne(ins => ins.ManagedDepartment)
                   .HasForeignKey<Department>(d => d.InsMngId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .IsRequired(false);

        }
    }
}
