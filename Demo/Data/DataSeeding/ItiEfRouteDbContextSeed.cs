using Demo.Data.Context;
using Demo.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Demo.Data.DataSeeding
{
    public static class ItiEfRouteDbContextSeed
    {
        internal static bool SeedData(ItiEfRouteDbContext dbContext)
        {
            try
            {
                if (!dbContext.Instructors.Any())
                {
                    //var InsData = File.ReadAllText("D:\\Career\\Backend\\Courses_Backend\\03-Eng Mariam Shindy\\06- EF\\Session 03\\Day 03 EF Core - Route\\Demo\\Data\\DataSeeding\\employees.json");
                    var InsData = File.ReadAllText("DataSeedingFiles\\Instructors.json");
                    // Json ==> C# Object DeSerialization
                    // C# Object ==> Json Serialization
                    var Instructors = JsonSerializer.Deserialize<List<Instructor>>(InsData);

                    if (Instructors?.Count > 0)
                        dbContext.Instructors.AddRange(Instructors);
                    dbContext.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
