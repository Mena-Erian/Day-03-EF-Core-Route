using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }

        public int DeptId { get; set; }
        public Department Department { get; set; }

        public ICollection<StudCourse> StudCourses { get; set; } = new HashSet<StudCourse>();
        public override string ToString()
            => $"Id: {Id}, FName: {FName}, LName: {LName}, Address: {Address}, Age: {Age}, DeptId: {DeptId}";
    }
}
