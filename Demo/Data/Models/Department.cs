using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int InstructorId { get; set; }
        public DateOnly HiringDate { get; set; }

        public ICollection<Instructor> Instructors { get; set; } = new HashSet<Instructor>();
        public ICollection<Student> Students { get; set; } = new HashSet<Student>();

        public Instructor InsManager { get; set; }
        public int? InsMngId { get; set; } //Fk

        public override string ToString()
            => $"Id: {Id}, Name: {Name}, InstructorId: {InstructorId}, HiringDate: {HiringDate}";
    }
}
