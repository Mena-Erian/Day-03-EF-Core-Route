using Demo.Data.Context;
using Demo.Data.DataSeeding;
using Demo.Data.Models;
using HelperUtilities;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Xml.Linq;

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

            #region Explicit Loading
            // 2 Request

            /// var ins = context.Instructors.FirstOrDefault(i => i.Id ==5);
            ///
            /// if (ins is not null)
            /// {
            ///     ins.Name.Print();
            ///     ins.DepartmentId.Print();
            ///
            ///
            ///     // Explicit Loading
            ///     context.Entry(ins).Reference(ins => ins.Department).Load();
            ///     ins.Department?.Print();
            /// }

            /// var dept = context.Departments.FirstOrDefault(i => i.Id == 50);
            /// 
            /// if (dept is not null)
            /// {
            ///     dept?.Name.Print();
            ///     dept?.Id.Print();
            /// 
            ///     context.Entry(dept).Collection(d => d.Instructors).Load();
            /// 
            /// 
            ///     dept.Instructors.PrintAll();
            /// }

            /// var dept = context.Departments.FirstOrDefault(i => i.Id == 50);
            /// 
            /// if (dept is not null)
            /// {
            ///     dept?.Name.Print();
            ///     dept?.Id.Print();
            /// 
            ///     context.Entry(dept).Collection(d => d.Instructors).Query().Where(ins => ins.Id > 20).Load();
            /// 
            /// 
            ///     dept.Instructors.PrintAll();
            /// }

            #endregion

            #region Lazy Loading
            // work implicitly like Explicit Loading (2 Requst)

            /// var Ins = context.Departments
            ///                  //.Include(d => d.Instructors)
            ///                  //.Include(d=> d.Students)
            ///                  .FirstOrDefault(d => d.Name == "HR");
            /// if (Ins is not null)
            /// {
            ///     Ins.Name.Print();
            ///     Ins.Instructors.PrintAll();
            /// }

            /// var dept = context.Departments.FirstOrDefault(d => d.Id == 90);
            /// 
            /// if (dept is not null)
            /// {
            ///     dept.Name.Print();
            ///     dept.Instructors.PrintAll();
            /// }
            #endregion

            #region Join Operators
            /// var result = context.Departments // outer
            ///                     .Join(context.Instructors // inner
            ///                           , dept => dept.Id
            ///                           , ins => ins.DepartmentId
            ///                           , (dept, ins) => new
            ///                           {
            ///                               DeptId = dept.Id,
            ///                               DeptName = dept.Name,
            ///                               InsName = ins.Name,
            ///                               InsId = ins.Id
            ///                           });
            /// 
            /// result = from Dept in context.Departments
            ///          join Ins in context.Instructors
            ///          on Dept.Id equals Ins.DepartmentId
            ///          select new
            ///          {
            ///              DeptId = Dept.Id,
            ///              DeptName = Dept.Name,
            ///              InsName = Ins.Name,
            ///              InsId = Ins.Id
            ///          };

            /// var result = context.Instructors // outer
            ///                     .Join(context.Departments,
            ///                           ins => ins.Id,
            ///                           dept => dept.InsMngId,
            ///                           (ins, dept) =>
            ///                           new
            ///                           {
            ///                               DeptId = dept.Id,
            ///                               DeptManged = dept.Name,
            ///                               InsManager = ins.Name,
            ///                               InsId = ins.Id
            ///                           });
            /// 
            /// 
            /// result = from ins in context.Instructors
            ///          join dept in context.Departments
            ///          on ins.Id equals dept.InsMngId
            ///          select new
            ///          {
            ///              DeptId = dept.Id,
            ///              DeptManged = dept.Name,
            ///              InsManager = ins.Name,
            ///              InsId = ins.Id
            ///          };
            /// 
            /// result.PrintAll();
            #endregion

            #region Group Join

            /// //Left Outer Join
            /// var result = context.Departments.GroupJoin(
            ///                                  context.Instructors,
            ///                                  dept => dept.Id,
            ///                                  ins => ins.DepartmentId,
            ///                                  (dept, inss) => new
            ///                                  {
            ///                                      Department = dept,
            ///                                      Instructors = inss
            ///                                  }).ToLookup(a => a.Department, a => a.Instructors);
            /// 
            /// result = (from dept in context.Departments
            ///           join ins in context.Instructors
            ///           on dept.Id equals ins.DepartmentId
            ///           into inss
            ///           select new
            ///           {
            ///               Department = dept,
            ///               Instructors = inss
            ///           }).ToLookup(a => a.Department, a => a.Instructors);
            /// 
            /// 
            /// foreach (var item in result)
            /// {
            ///     Console.Write("Key: "); item.Key.Print();
            ///     Console.WriteLine("Elements: ");
            ///     foreach (var std in item) std.PrintAll();
            ///     Console.WriteLine("------------------------------------\n");
            /// }

            /// var result = context.Instructors.GroupJoin(
            ///                                  context.Departments,
            ///                                  ins => ins.DepartmentId,
            ///                                  dept => dept.Id,
            ///                             (ins, depts) =>
            ///                                  new
            ///                                  {
            ///                                      Instructor = ins,
            ///                                      Departments = depts
            ///                                  }
            /// 
            ///     ).ToLookup(a => a.Instructor, a => a.Departments);
            /// 
            /// result = (from ins in context.Instructors
            ///           join dept in context.Departments
            ///           on ins.DepartmentId equals dept.Id
            ///           into depts
            ///           select new
            ///           {
            ///               Instructor = ins,
            ///               Departments = depts
            ///           }).ToLookup(a => a.Instructor, a => a.Departments);
            /// 
            /// foreach (var item in result)
            /// {
            ///     Console.Write("Key: "); item.Key.Print();
            ///     Console.WriteLine("Elements: ");
            ///     foreach (var std in item) std.PrintAll();
            ///     Console.WriteLine("------------------------------------\n");
            /// }


            var result = context.Departments.GroupJoin(
                                             context.Instructors,
                                             dept => dept.Id,
                                             ins => ins.DepartmentId,
                                             (dept, inss) => new
                                             {
                                                 Department = dept,
                                                 Instructors = inss
                                             }).Where(a => a.Instructors.Count() > 2).ToLookup(a => a.Department, a => a.Instructors);

            result = (from dept in context.Departments
                      join ins in context.Instructors
                      on dept.Id equals ins.DepartmentId
                      into inss
                      where inss.Count() > 2
                      select new
                      {
                          Department = dept,
                          Instructors = inss
                      }).ToLookup(a => a.Department, a => a.Instructors);


            foreach (var item in result)
            {
                Console.Write("Key: "); item.Key.Print();
                Console.WriteLine("Elements: ");
                foreach (var std in item) std.PrintAll();
                Console.WriteLine("------------------------------------\n");
            }

            #endregion

        }
    }
}
