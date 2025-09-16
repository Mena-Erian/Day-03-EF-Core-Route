using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Models
{
    public class Topic
    {
        [ForeignKey(nameof(Course.TopicId))]
        public int Id { get; set; }
        [Required]
        //[Index("IX_Topic_Name", IsUnique = true)] 
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<Course> Courses { get; set; }

        public override string ToString()
            => $"Id: {Id}, Name: {Name}";
    }
}
