using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TouristTourGuide.Data.Models.Sql.Models;

namespace TouristTourGuide.Data.Configuration
{
    public class TouristTourConfiguration : IEntityTypeConfiguration<TouristTour>
    {
        public void Configure(EntityTypeBuilder<TouristTour> builder)
        {
            builder.Property(d => d.PricePerPerson).HasPrecision(18, 2);
        }
    }
}
