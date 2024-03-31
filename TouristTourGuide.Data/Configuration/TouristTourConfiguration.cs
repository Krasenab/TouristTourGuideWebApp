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
                TourName = "Beatles Tour incl. Abbey Road with Richard Porter",
                Duaration = "2.5 hours",
                PricePerPerson = 45.75m,
                FullDescription = "Experience the London of The Beatles with Richard Porter, author of the book Guide to the Beatles London. Discover the locations and landmarks where The Fab Four recorded, lived, and socialized in London during the Swinging Sixties."

            };

            return touristTours;

        } 


    }
}
