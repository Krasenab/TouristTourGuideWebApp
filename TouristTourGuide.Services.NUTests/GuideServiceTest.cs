using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;

using TouristTourGuide.Data;
using TouristTourGuide.Data.Models;
using TouristTourGuide.ViewModels.UserGuideViewModels;
using TouristTourGuide.Data.Models.Sql.Models;

using Moq;
using Moq.EntityFrameworkCore;

using static TouristTourGuide.Services.NUTests.DbMockSeedData;
using TouristTourGuide.Data.DataProcessor;
using TouristTourGuide.Data.Configuration;
using TouristTourGuide.Services.Interfaces;
using TouristTourGuide.ViewModels.GuideUserViewModels;


namespace TouristTourGuide.Services.NUTests
{
    public class GUideServiceTest
    {
        private  DbContextOptions<TouristTourGuideDbContext> optionsBuilder;        
        private TouristTourGuide.Data.TouristTourGuideDbContext dbContextOptions;
        private IGuideUserService gUS;
 
        
        

        public GUideServiceTest()
        {
                 
        }
        [OneTimeSetUp]
        public void OneTimeSetUp() 
        {
            this.optionsBuilder = new DbContextOptionsBuilder<TouristTourGuideDbContext>().UseInMemoryDatabase("TouristTourGuideInMemory" + Guid.NewGuid().ToString()).Options;
           dbContextOptions= new TouristTourGuideDbContext(optionsBuilder);           
            SeedDatabase(dbContextOptions);
            this.gUS = new GuideUserService(this.dbContextOptions);
        }

        [SetUp]
        public void Setup()
        {

        }
        [Test]
        public void CreateGuideUserShouldReturnTrueWhenCreatedSuccessfuly() 
        {
            ApplicationUser? apUser = dbContextOptions.ApplicationUsers.Where(x => x.Email=="mockGuide1@gmail.com").FirstOrDefault();
            bool isCreated = false;          
          
            BecomeGuideUserViewModel becomeGuideUserView = new BecomeGuideUserViewModel()
            {
                AboutTheActivityProvider = "Moking test",
                Name = "CreateMethod",
                LegalFirmName = "Test create gUsers method",
                RegisteredAddress = "Moke st. 123",
                Email = "TestMethod@gmail.com",
                PhoneNumber = "Moke12334567",
                CompanyRegistrationNumber = "FK001122"
            };

            gUS.CreateGuide(becomeGuideUserView, apUser.Id.ToString());

            isCreated = dbContextOptions.GuideUsers.Where(x => x.Email== "TestMethod@gmail.com").Any();

            Assert.True(isCreated);
           
        }
        [Test]
        public void IsUserGuideReturnTrueWhenUserIsGuide() 
        {
            GuideUser? guideUser = dbContextOptions.GuideUsers.FirstOrDefault();
            string guideUserAppUserId = guideUser.ApplicationUserId.ToString();

            bool result = gUS.isUserGuide(guideUserAppUserId);

            Assert.True(result);
        }

        [Test]
        public void GUideUserInfoShoudReturnTrueWhenGetObejct()
        {
            var mockGuideUser = dbContextOptions.GuideUsers.FirstOrDefault(); // get the guide user appUserId from InMemory DB
            string guideUserAppUserId = mockGuideUser.ApplicationUserId.ToString();
            var getDataFromService = gUS.GuidUserInfo(guideUserAppUserId);
            bool isGet = false;
            if(getDataFromService != null ) 
            {
                isGet = true;
            }
             
            Assert.True(isGet);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            // Изчистване на dbContextOptions защото не ми позволява да инициализирам обек от ДБ контекста
            dbContextOptions?.Dispose();
        }
    }
}