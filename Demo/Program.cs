using Demo.Data.Context;
using Demo.Data.DataSeeding;
using Demo.Data.Models;
using HelperUtilities;
using Microsoft.EntityFrameworkCore;
using System.Net;

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

            #region Eager Loading

            /// var Ins = context.Instructors.FirstOrDefault(ins => ins.Id == 5);
            /// if (Ins is not null)
            /// {
            ///     Ins.Name.Print();
            ///     Ins.DepartmentId.Print();
            ///     Ins.Department?.Name.Print();
            /// 
            ///     var dept = (from d in context.Departments
            ///                where d.Id == Ins.DepartmentId
            ///                select d).FirstOrDefault();
            ///   
            ///     dept?.Name.Print();
            /// 
            ///     // 2 requests happened here
            /// }

            /// var Ins = context.Instructors.Include(ins => ins.ManagedDepartment)
            ///     //it make inner join in case they is mandatory navigational property
            ///     //but if it Optional NavProp it will make LEFT join
            ///     .FirstOrDefault(ins => ins.Id == 5);
            /// if (Ins is not null)
            /// {
            ///     Ins.Name.Print();
            ///     Ins.DepartmentId.Print();
            ///     Ins.ManagedDepartment?.Name.Print(" <== Department Name");
            /// }

            /// var Ins = context.Instructors
            ///     .Include(ins => ins.Department)
            ///     .Include(ins => ins.ManagedDepartment)
            ///     .FirstOrDefault(ins => ins.Id == 5);
            /// if (Ins is not null)
            /// {
            ///     Ins.Name.Print();
            ///     Ins.DepartmentId.Print();
            ///     Ins.Department?.Name.Print(" <== Department Name");
            ///     Ins.ManagedDepartment?.Name.Print(" <== ManagedDepartment Name");
            /// }

            /// var Ins = context.Instructors
            ///     .Include(ins => ins.Department)
            ///     .ThenInclude(d => d.InsManager)
            ///     .FirstOrDefault(ins => ins.Id == 5);
            /// 
            /// if (Ins is not null)
            /// {
            ///     Ins.Name.Print();
            ///     Ins.DepartmentId.Print();
            ///     Ins.Department?.Name.Print(" <== Department Name");
            ///     
            ///     Ins.Department?.Name.Print(" <== Department Name");
            ///     Ins.Department?.InsManager.Name.Print(" <== Department.InsManager.Name");
            ///     Ins.Department?.InsManager.Bouns.Print(" <== Department.InsManager.Bouns");
            /// 
            /// 
            ///     Ins.ManagedDepartment?.Name.Print(" <== ManagedDepartment Name");
            ///     Ins.ManagedDepartment?.InsManager.Name.Print(" <== ManagedDepartment?.InsManager.Name");
            ///     Ins.ManagedDepartment?.InsManager.Bouns.Print(" <== ManagedDepartment?.InsManager.Bouns");
            /// }

            /// var Ins = context.Departments
            ///     .Include(d=> d.Instructors)
            ///     //.Include(d=> d.Students)
            ///     .FirstOrDefault(d => d.Name == "HR");
            /// if (Ins is not null)
            /// {
            ///     Ins.Instructors  .PrintAll();
            /// }

            /// var dept = context.Departments
            ///     .Include(d => d.Instructors)
            ///     .Where(d => d.Name == "HR")
            ///     .Select(x => new { x.Name, x.Instructors })
            ///     ;
            /// if (dept is not null)
            /// {
            ///     var temp = dept.FirstOrDefault();
            ///     temp?.Name.Print();
            ///     temp?.Instructors.PrintAll();
            /// }

            #endregion



        }
    }
}
