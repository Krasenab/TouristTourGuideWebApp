using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TouristTourGuide.Data.Models.Sql.Models;

namespace TouristTourGuide.Data.Configuration
{
    public class TouristTourConfiguration : IEntityTypeConfiguration<TouristTour>
    {
        public void Configure(EntityTypeBuilder<TouristTour> builder)
        {
            builder.Property(p => p.PricePerPerson).HasPrecision(18, 2);
            builder.Property(d=>d.CreatedOn).HasDefaultValue(DateTime.UtcNow);
        }

        private List<TouristTour> SetTouristTours() 
        {
            List<TouristTour> touristTours = new List<TouristTour>();

            TouristTour t = new TouristTour()
            {

            };

            return touristTours;

        } 


    }
}
