﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Models
{
    public class CourseInstructor
    {
        public int CourseId { get; set; }
        public int InstructorId { get; set; }
        public int Evaluation { get; set; }


        public Course Course { get; set; }
        public Instructor Instructor { get; set; }
    }
}
