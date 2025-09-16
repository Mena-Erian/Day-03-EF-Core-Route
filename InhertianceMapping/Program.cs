using HelperUtilities;
using InhertianceMapping.Data;
using InhertianceMapping.Data.Modals;

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


        }
    }
}
