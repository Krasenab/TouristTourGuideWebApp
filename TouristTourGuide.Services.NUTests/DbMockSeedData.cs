using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristTourGuide.Data;
using TouristTourGuide.Data.Models.Sql.Models;

namespace TouristTourGuide.Services.NUTests
{
    public static class DbMockSeedData
    {
        private static ApplicationUser GuideUsers;
        private static ApplicationUser AppUser;
        private static GuideUser gUser;

     

        public static void SeedDatabase(TouristTourGuideDbContext ttgDbContext) 
        {
            GuideUsers  = new ApplicationUser()
            {

                FirstName = "Fake Guide",
                NormalizedUserName = "FakeGuideMockSchema",
                Email = "mockGuide@gmail.com",
                EmailConfirmed = true,
                LastName = "FakeOv",
                NormalizedEmail = "MOCKGUIDE@GMAIL.COM",
                PasswordHash = "f6e0a1e2ac41945a9aa7ff8a8aaa0cebc12a3bcc981a929ad5cf810a090e11ae",
                SecurityStamp = "356328d3-3e32-46ff-a5ae-103a74b82a69",
               /* Id = new Guid("ebd8fef2-b253-4e99-8ae4-77d0887d41b9"),*/
                TwoFactorEnabled=false


                
            };
            AppUser = new ApplicationUser() 
            {
                FirstName = "Fake User",
                NormalizedUserName = "UserFakeMockSchema",
                Email = "mockGuide@gmail.com",
                EmailConfirmed = true,
                LastName = "FakeOv",
                NormalizedEmail = "MOCKUSER@GMAIL.COM",
                TwoFactorEnabled = false,
                PasswordHash = "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3",
                SecurityStamp = "e37bb679-4659-4bf9-a604-eca04ad2f80b"
                //Id = new Guid("154096d3-1656-4b84-b3a3-b866ee951077")
               
            };

            gUser = new GuideUser() 
            {
                ApplicationUser = GuideUsers,
                RegisteredAddress = "FakeStreet",
                AboutTheActivityProvider = "Best activity provider",
                CompanyRegistrationNumber = "UK0123456",
                LastName = GuideUsers.LastName,
                LegalFirmName = "BiteCoin EOOD",
                Email = "ALOMOCK@gmail.com",
                PhoneNumber = "0998081234"
            };
            ttgDbContext.ApplicationUsers.Add(GuideUsers);
            ttgDbContext.ApplicationUsers.Add(AppUser);
            ttgDbContext.GuideUsers.Add(gUser); 
            ttgDbContext.SaveChanges();
            
            
        }
    }
}
