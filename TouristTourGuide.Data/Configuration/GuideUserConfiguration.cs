using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TouristTourGuide.Data.Models.Sql.Models;

namespace TouristTourGuide.Data.Configuration
{
    public class GuideUserConfiguration : IEntityTypeConfiguration<GuideUser>
    {
        public void Configure(EntityTypeBuilder<GuideUser> builder)
        {
          //  builder.HasData(SetGuideUser());   
        }

        //private GuideUser SetGuideUser()
        //{
        //    GuideUser user = new GuideUser()
        //    {
        //        Id = Guid.Parse("9A4399F1-422B-4911-BCCB-F3F01004235A"),
        //        Name = "Richard Porter",
        //        LegalFirmName = "London Northwest.com Ltd",
        //        RegisteredAddress = "75, Birchen Grove NW9 8RY London, London",
        //        AboutTheActivityProvider = "One of the good tour guides u can find in London",
        //        Email = "RichardPorter@gmail.com",
        //        PhoneNumber = "0887123123",
        //        ApplicationUserId = Guid.Parse("CA26C134-C7F2-46BD-E086-08DC5FDF58F6"),
        //        CompanyRegistrationNumber = "UK123456",

        //    };
        //    return user;


        //}
    }
}
