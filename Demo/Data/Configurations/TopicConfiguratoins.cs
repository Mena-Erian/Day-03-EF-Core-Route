using Demo.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Configurations
{
    internal class TopicConfiguratoins : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            // One(Topic) to Many(Course)

            builder.HasMany(t => t.Courses)
                   .WithOne(c => c.Topic)
                   .HasForeignKey(c => c.TopicId)
                   .IsRequired()
                   ;
        }
    }
}
