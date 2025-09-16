using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InhertianceMapping.Data.Modals
{
    internal class PartTimeEmployee : Employee
    {
        public int HourRate { get; set; }
        public int CountOfHours { get; set; }
        public override string ToString()
           => $"{base.ToString()}, HourRate: {HourRate}, CountOfHours: {CountOfHours}";

    }
}
