using DatabaseFirst.Data;
using DatabaseFirst.Data.Models;
using HelperUtilities;
using Microsoft.EntityFrameworkCore;

namespace DatabaseFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new NorthwindContext();

            #region DQL
            //DQL ==> FromSqlRaw, FromSqlInterpolation

            //var catId = 2;
            //var products = context.Products.FromSqlRaw("select *\r\nfrom Products as P\r\nwhere P.CategoryID ={0}", catId);

            //var catId = 2;
            //var products = context.Products.FromSqlInterpolated($"select *\r\nfrom Products as P\r\nwhere P.CategoryID ={catId}");

            //foreach (var item in products)
            //{
            //item.ProductId.Print();
            //item.ProductName.Print();
            //item.CategoryId.Print();
            //}
            #endregion

            #region DML
            //ExecuteSqlRaw(), ExecuteSqlInterpolated()

            //var id = 2;
            //var numOfRows = context.Database.ExecuteSqlRaw("Update Products\r\nset ProductName = 'Cup of Coffee'\r\nwhere ProductID = {0}", id);
            //numOfRows.Print();

            /// var id = 90;
            /// var numOfRows = context.Database.ExecuteSqlInterpolated($"Delete from products\r\nwhere ProductID = {id};");
            /// numOfRows.Print();
            #endregion


        }
    }
}
