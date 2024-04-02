using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TouristTourGuide.Data.Models.Sql.Models;
namespace TouristTourGuide.Data.Configuration
{
    public class VoteConfiguration : IEntityTypeConfiguration<Vote>
    {
        public void Configure(EntityTypeBuilder<Vote> builder)
        {
           builder.HasOne(t=>t.TouristTour)
                .WithMany(v=>v.Votes)
                .HasForeignKey(tid=>tid.TouristTourId)
                .OnDelete(DeleteBehavior.Restrict);                               
        }
    }
}
