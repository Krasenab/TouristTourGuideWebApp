using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.IdentityModel.Tokens;
using TouristTourGuide.Data.Models.Sql.Models;

namespace TouristTourGuide.Data.Configuration
{
    public class TouristTourConfiguration : IEntityTypeConfiguration<TouristTour>
    {
        public void Configure(EntityTypeBuilder<TouristTour> builder)
        {
            builder.Property(p => p.PricePerPerson).HasPrecision(18, 2);
            builder.Property(d => d.CreatedOn).HasDefaultValue(DateTime.UtcNow);

            builder.HasOne(c => c.Category)
                .WithMany(t => t.TouristTours)
                .HasForeignKey(ca => ca.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(l => l.Location)
                .WithMany(t => t.TouristTours)
                 .HasForeignKey(ca => ca.LocationId)
                .OnDelete(DeleteBehavior.Restrict);
       
                

            //builder.HasData(SetTouristTours());
        }

        //private List<TouristTour> SetTouristTours()
        //{
        //    List<TouristTour> touristTours = new List<TouristTour>();

        //    TouristTour t = new TouristTour()
        //    {
        //        Id = Guid.Parse("f4e0c782-d1a4-42d1-9182-90b6fb2935e4"),
        //        TourName = "Beatles Tour incl. Abbey Road with Richard Porter",
        //        Duaration = "2.5 hours",
        //        PricePerPerson = 45.75m,
        //        Highlights = "Discover where The Beatles recorded, lived, and socialized in 1960s London and many others",
        //        FullDescription = "Experience the London of The Beatles with Richard Porter, author of the book Guide to the Beatles London." +
        //        "Discover the locations and landmarks where The Fab Four recorded, lived, and socialized in London during the Swinging Sixties.",
        //        GuideUserId = Guid.Parse("9A4399F1-422B-4911-BCCB-F3F01004235A"),
        //        MeetingPoint = "Meet Richard outside Exit 1 of Tottenham Court Road Station. He will be holding 'Beatles Walks' leaflets and wearing a Beatles shirt or hat.",
        //        CategoryId = 1,
        //        LocationId = 1
        //    };

        //    touristTours.Add(t);

        //    return touristTours;

        //}


    }
}
