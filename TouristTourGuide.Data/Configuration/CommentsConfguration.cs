using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristTourGuide.Data.Models.Sql.Models;

namespace TouristTourGuide.Data.Configuration
{
    public class CommentsConfguration : IEntityTypeConfiguration<Comments>
    {
        public void Configure(EntityTypeBuilder<Comments> builder)
        {
           
          builder.HasOne(t=>t.TouristTour)
                .WithMany(cc=>cc.Comments)
                .HasForeignKey(f=>f.TouristTourId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.CreatedOn).HasDefaultValue(DateTime.UtcNow);
                
        }
    }
}
