using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TouristTourGuide.Data.Models.Sql.Models;
namespace TouristTourGuide.Data.Configuration
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasData(SetLocation());   
        }

        private Location SetLocation() 
        {
            Location l = new Location()
            {
                Id = 1,
                Country = "UK",
                City = "London"
            };

            return l;
        }
    }
}
