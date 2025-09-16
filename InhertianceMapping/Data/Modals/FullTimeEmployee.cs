using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InhertianceMapping.Data.Modals
{
    internal class FullTimeEmployee : Employee
    {
        public DateTime  StartDate { get; set; }
        public decimal Salary { get; set; }
        public override string ToString()
         => $"{base.ToString()}, Salary: {Salary}, Start Date: {StartDate}";

    }
}
