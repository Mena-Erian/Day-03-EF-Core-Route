using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Models
{
    [PrimaryKey(nameof(StudId), nameof(CourseId))]
    public class StudCourse
    {
        [ForeignKey(nameof(Student))]
        public int StudId { get; set; }

        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }


        public Student Student { get; set; }
        public Course Course { get; set; }


        public int Grade { get; set; }
    }
}
