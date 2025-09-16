using HelperUtilities;
using InhertianceMapping.Data;

namespace InhertianceMapping
{
    internal class Program
    {
        static void Main(string[] args)
        {
           using var context = new MyCompanyDbContext();

            var partTime = from e in context.PartTimeEmployees
                           select e;
            partTime.PrintAll();

            var fullTime = from e in context.FullTimeEmployees
                           select e;
            fullTime.PrintAll();
        }
    }
}
