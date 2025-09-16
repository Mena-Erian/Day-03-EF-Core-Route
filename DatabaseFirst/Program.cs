using DatabaseFirst.Data;
using HelperUtilities;

namespace DatabaseFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new NorthwindContext();

            foreach (var prod in context.Products)
            {
                prod.ProductName.Print();
            }
        }
    }
}
