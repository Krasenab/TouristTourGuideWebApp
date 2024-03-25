using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TouristTourGuide.Data.Models.Sql.Models;

namespace TouristTourGuide.Data.Configuration
{
    public class TouristToursDatesConfig:IEntityTypeConfiguration<TouristTourDates>
    {
        public void Configure(EntityTypeBuilder<TouristTourDates> builder) 
        {
            builder.HasKey(x => new { x.TouristTourId, x.DatesId });
        }
    }
}
