using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Models
{
    public class Course
    {
        [Key]
        [Column("Id")]
        public int CrsId { get; set; }
        [Range(1, 30)]   // BY MONTHES
        public int Duration { get; set; } // BY MONTHES
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; } = null!;
        [AllowNull]
        [MaxLength(500), MinLength(20)]
        public string Description { get; set; }
        

        [NotNull]
        public int TopicId { get; set; }
        public virtual Topic Topic { get; set; }

        public virtual ICollection<CourseInstructor> CourseInstructors { get; set; } = new HashSet<CourseInstructor>();

        public override string ToString()
            => $"CrsId: {CrsId}, Name: {Name}, Duration: {Duration}, Description: {Description}, TopicId: {TopicId}";
    }
}
