using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TouristTourGuide.Data.Models.Sql;
using TouristTourGuide.Data.Models.Sql.Models;
namespace TouristTourGuide.Data.Configuration
{
    public class ToursBookingConfiguration:IEntityTypeConfiguration<TouristTourBooking>
    {       
        public void Configure(EntityTypeBuilder<TouristTourBooking> builder)
        {
           builder.Property(d=>d.TotalPrice).HasPrecision(18,2);
        }
    }
}
