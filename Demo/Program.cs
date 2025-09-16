using Demo.Data.Context;
using Demo.Data.DataSeeding;
using Demo.Data.Models;
using HelperUtilities;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            using ItiEfRouteDbContext context = new ItiEfRouteDbContext();
            #region DataSeeding

            // context.Departments.Add(new Department()
            // {
            //     Name = "Operating System",
            //     HiringDate = new DateOnly(1002,8,8)
            // });

            /// var d = DateTime.Now;
            /// var dateOnly = new DateOnly(d.Year, d.Month, d.Day);
            /// var departments = new List<Department>()
            /// {
            ///     new Department(){ Name = "Media", HiringDate = dateOnly},
            ///     new Department(){ Name = "HR", HiringDate = dateOnly},
            ///     new Department(){ Name = "CS", HiringDate = dateOnly},
            /// };
            /// 
            /// context.Departments.AddRange(departments);
            /// context.SaveChanges();
            /// 

            //Using Migration


            /// var flag = ItiEfRouteDbContextSeed.SeedData(context);
            /// 
            /// if (flag)
            ///     "Done".Print();
            /// else "Not Completed".Print();

            #endregion

        }
    }
}
