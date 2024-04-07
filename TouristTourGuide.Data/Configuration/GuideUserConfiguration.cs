using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TouristTourGuide.Data.Models.Sql.Models;

namespace TouristTourGuide.Data.Configuration
{
    public class GuideUserConfiguration : IEntityTypeConfiguration<GuideUser>
    {
        public void Configure(EntityTypeBuilder<GuideUser> builder)
        {
           // builder.HasData(SetGuideUser());   
        }

        private GuideUser SetGuideUser() 
        {
            GuideUser user = new GuideUser()
            {
               Id = Guid.Parse("E92DF1B5-20F5-49AE-8917-D2C378EA18C1"),
                Name = "Richard Porter",
                LegalFirmName = "London Northwest.com Ltd",
                RegisteredAddress = "75, Birchen Grove NW9 8RY London, London",
                AboutTheActivityProvider = "One of the good tour guides u can find in London",
                Email = "RichardPorter@gmail.com",
                PhoneNumber = "0887123123",
                ApplicationUserId = Guid.Parse("Bdd9c20e-21ab-4d92-acb2-08dc51b45211"),
                CompanyRegistrationNumber = "UK123456",
               
            };
            return user;
        }
    }
}
