using InhertianceMapping.Data.Modals;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InhertianceMapping.Data
{
    internal class MyCompanyDbContext : DbContext
    {
        public DbSet<FullTimeEmployee> FullTimeEmployees { get; set; }
        public DbSet<PartTimeEmployee> PartTimeEmployees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=InheritanceMappingG01;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
            optionsBuilder.UseSeeding((context, _) =>
            {
                /// context.Set<FullTimeEmployee>().Add(
                ///     new FullTimeEmployee() { Name = "Soha", Age = 20, Salary = 5000, StartDate = DateTime.Now, Address = "Cairo" }
                ///     );
                /// context.Set<PartTimeEmployee>().Add(
                ///     new PartTimeEmployee() { Name = "Soha", Age = 20, HourRate = 200, CountOfHours = 6, Address = "Alex" }
                ///     );
                //context.SaveChanges();
            });
        }
    }
}
