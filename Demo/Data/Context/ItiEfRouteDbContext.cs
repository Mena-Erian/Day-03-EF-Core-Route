using Demo.Data.Configurations;
using Demo.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Context
{

    internal class ItiEfRouteDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        //public DbSet<Topic> Topics { get; set; }
        //public DbSet<StudCourse> StudCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ITIEF;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False")
                          .UseLazyLoadingProxies();
            //optionsBuilder.UseLazyLoadingProxies();
            //base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /// modelBuilder.ApplyConfiguration(new StudentConfigurations());
            /// modelBuilder.ApplyConfiguration(new InstructorConfigurations());
            /// modelBuilder.ApplyConfiguration(new DepartmnetConfigurations());
            /// modelBuilder.ApplyConfiguration(new CourseConfigurations());
            /// modelBuilder.ApplyConfiguration(new TopicConfiguratoins());

            modelBuilder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());

            var d = DateTime.Now;
            var dateOnly = new DateOnly(d.Year, d.Month, d.Day);
            /// var departments = new List<Department>()
            /// {
            ///     new Department(){ Name = "Media", HiringDate = dateOnly},
            ///     new Department(){ Name = "HR", HiringDate = dateOnly},
            ///     new Department(){ Name = "CS", HiringDate = dateOnly},
            /// };

            modelBuilder.Entity<Department>().HasData(
           new Department() { Id = 70, Name = "Digital", HiringDate = dateOnly },
                new Department() { Id = 80, Name = "Marketing", HiringDate = dateOnly },
                new Department() { Id = 90, Name = "Salles", HiringDate = dateOnly }
                );


        }
    }
}
