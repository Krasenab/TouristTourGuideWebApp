using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TouristTourGuide.Data;
using TouristTourGuide.Data.Models.Sql.Models;
using TouristTourGuide.Data.DataProcessor;

namespace TouristTourGuide.Services.NUTests
{
    public static class DbMockSeedData
    {
        private static ApplicationUser GuideUsers;
        private static ApplicationUser AppUser;
        private static ApplicationUser AppUser1;
        
        private static GuideUser gUser;
        private static Category category;       
        private static Location location;
        private static TouristTour tour;
        private static TouristTour tour1;
        private static Category category1;
        private static Category category2;


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
            AppUser1 = new ApplicationUser()
            {
                FirstName = "TestPerson",
                NormalizedUserName = "TESTPERSON",
                Email = "mockGuide1@gmail.com",
                EmailConfirmed = true,
                LastName = "FakeOvFake",
                NormalizedEmail = "MOCKGUIDE1@GMAIL.COM",
                TwoFactorEnabled = false,
                PasswordHash = "0ffe1abd1a08215353c233d6e009613e95eec4253832a761af28ff37ac5a150c",
                SecurityStamp = "10ef2ad5-e76a-4da3-8707-e8d0332ba860"
                //Id = new Guid("154096d3-1656-4b84-b3a3-b866ee951077")

            };

            gUser = new GuideUser() 
            {
                Name = "FAKE GUIDE",
                ApplicationUser = GuideUsers,
                RegisteredAddress = "FakeStreet",
                AboutTheActivityProvider = "Best activity provider",
                CompanyRegistrationNumber = "UK0123456",
                LastName = GuideUsers.LastName,
                LegalFirmName = "BiteCoin EOOD",
                Email = "ALOMOCK@gmail.com",
                PhoneNumber = "0998081234"
               
            };
            

            // Category data
            category = new Category()
            {
                Name = "Unit Test"
            };
            category1 = new Category()
            {
                Name = "Unit test category 1"
            };
            category2 = new Category()
            {
                Name = "Unit test category 2"
            };

            location = new Location()
            {
                Country = "BuggLandia"
            };
            
            ttgDbContext.Categories.Add(category);
            ttgDbContext.Categories.Add(category1);
            ttgDbContext.Categories.Add(category2);
            ttgDbContext.Locations.Add(location);
            ttgDbContext.ApplicationUsers.Add(GuideUsers);
            ttgDbContext.ApplicationUsers.Add(AppUser);
            ttgDbContext.ApplicationUsers.Add(AppUser1);
            ttgDbContext.GuideUsers.Add(gUser);

            // Tour data 

            tour = new TouristTour()
            {
                TourName = "NUnit Tour Full",
                Duaration = "100000000 days",
                StartEndHouers = "24:00 to 00:00",
                NotSuitableFor = "NULL",
                CategoryId = category.Id,
                FullDescription = "Unit tests tour is a great tour ever",
                Location = location,
                MeetingPoint = "NULL",
                PricePerPerson = 400000,
                GuideUser = gUser

            };
            tour1 = new TouristTour()
            {
                TourName = "Fake Tour 1",
                Duaration = "100 days",
                StartEndHouers = "19:00 to 00:00",
                NotSuitableFor = "NULL",
                CategoryId = category1.Id,
                Category = category1,
                FullDescription = "Unit tests tour is a great tour ever",
                Location = location,
                MeetingPoint = "NULL",
                PricePerPerson = 500000,
                GuideUser = gUser
            };
            ttgDbContext.TouristsTours.Add(tour);
            ttgDbContext.TouristsTours.Add(tour1);

            TouristTourBooking tourBooking = new TouristTourBooking()
            { 
                ApplicationUser = AppUser1,
                TouristTour = tour1,
                Email = "person@gmaill.com",
                PhoneNumber = "00011122",
                TouristTourId = tour1.Id,
                CountOfPeople = 1,
                BookedDate = DateTime.Now,
                
            };
            ttgDbContext.TouristTourBookings.Add(tourBooking);

            ttgDbContext.SaveChanges();           
        }
      
    }
}
