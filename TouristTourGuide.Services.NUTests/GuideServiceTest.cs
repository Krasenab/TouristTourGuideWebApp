using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;

using TouristTourGuide.Data;
using TouristTourGuide.Data.Models;
using TouristTourGuide.ViewModels.UserGuideViewModels;
using TouristTourGuide.Data.Models.Sql.Models;

using Moq;
using Moq.EntityFrameworkCore;

using static TouristTourGuide.Services.NUTests.DbMockSeedData;


namespace TouristTourGuide.Services.NUTests
{
    public class GUideServiceTest
    {
        private  DbContextOptions<TouristTourGuideDbContext> optionsBuilder;        
        private TouristTourGuide.Data.TouristTourGuideDbContext dbContextOptions;
 
        
        

        public GUideServiceTest()
        {
                 
        }
        [OneTimeSetUp]
        public void OneTimeSetUp() 
        {
            this.optionsBuilder = new DbContextOptionsBuilder<TouristTourGuideDbContext>().UseInMemoryDatabase("TouristTourGuideInMemory" + Guid.NewGuid().ToString()).Options;
           dbContextOptions= new TouristTourGuideDbContext(optionsBuilder); 
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GUideUserInfoReturnGuideUserListWhenExist()
        {
         
        }
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            // Изчистване на dbContextOptions защото не ми позволява да инициализирам обек от ДБ контекста
            dbContextOptions?.Dispose();
        }
    }
}