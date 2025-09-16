using HelperUtilities;
using InhertianceMapping.Data;
using InhertianceMapping.Data.Modals;
using Microsoft.EntityFrameworkCore;

namespace InhertianceMapping
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new MyCompanyDbContext();

            #region TPCC
            /// var partTime = from e in context.PartTimeEmployees
            ///                select e;
            /// partTime.PrintAll();
            /// 
            /// var fullTime = from e in context.FullTimeEmployees
            ///                select e;
            /// fullTime.PrintAll(); 
            #endregion

            #region TPH
            /// var emp = context.Employees;
            /// emp.OfType<PartTimeEmployee>().PrintAll();
            /// emp.OfType<FullTimeEmployee>().PrintAll();
            #endregion

            #region TPC Table Per Class [Table Per Type]
            //var emps = context.Employees.OfType<FullTimeEmployee>();
            //emps.PrintAll();
           
            /// var emps = context.Employees;
            /// 
            /// if (emps.Any())
            /// {
            ///     //emps.OfType<FullTimeEmployee>().PrintAll();
            ///     emps.OfType<PartTimeEmployee>().PrintAll();
            /// }
            #endregion
        }
    }
}
