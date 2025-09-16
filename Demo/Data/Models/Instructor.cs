using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Demo.Data.Models
{
    public class Instructor
    {
        //[JsonIgnore(Condition = JsonIgnoreCondition.Always)] // i write it just when i was make desterilization from json file
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        //[AllowedValues(100, 200, 300, 400, 500)]
        public int Bouns { get; set; }
        public required decimal Salary { get; set; }
        //public string Address { get; set; } = null!;
        public Address Address { get; set; }
        public int? HourRate { get; set; }

        public virtual Department Department { get; set; }
        public int DepartmentId { get; set; }


        public virtual ICollection<CourseInstructor> CourseInstructors { get; set; } = new HashSet<CourseInstructor>();

        public virtual Department? ManagedDepartment { get; set; }

        public override string ToString()
            => $"Id: {Id}, Name: {Name}, Bouns: {Bouns}, Salary: {Salary}, Address: {Address}, HourRate: {HourRate}, DepartmentId: {DepartmentId}";
    }
    //public ICollection<Course> Courses { get; set; } = new HashSet<Course>();
}
