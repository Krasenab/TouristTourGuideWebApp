using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TouristTourGuide.Data.Models.Sql.Models;

namespace TouristTourGuide.Data.Configuration
{
    public class GuideUserConfiguration : IEntityTypeConfiguration<GuideUser>
    {
        public void Configure(EntityTypeBuilder<GuideUser> builder)
        {
            
        }

        private GuideUser SetGuideUser() 
        {
            GuideUser user = new GuideUser()
            {
                Id = Guid.NewGuid(),
                Name = "Richard Porter",
                LegalFirmName = "London Northwest.com Ltd",
                RegisteredAddress = "75, Birchen Grove NW9 8RY London, London",
                AboutTheActivityProvider = "One of the good tour guides u can find in London",
                Email = "RichardPorter@gmail.com"


            };
            return user;
        }
    }
}
