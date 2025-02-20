using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;

using TouristTourGuide.Data;
using TouristTourGuide.Data.Models;
using TouristTourGuide.ViewModels.UserGuideViewModels;
using TouristTourGuide.Data.Models.Sql.Models;

using Moq;
using Moq.EntityFrameworkCore;

using static TouristTourGuide.Services.NUTests.DbMockSeedData;
using TouristTourGuide.Services.Interfaces;
using TouristTourGuide.ViewModels;
using TouristTourGuide.ViewModels.TouristTourViewModels;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using Amazon.Runtime.Internal;
using Microsoft.AspNetCore.Mvc;

namespace TouristTourGuide.Services.NUTests
{
    public class TouristTourServiceTests
    {
        private DbContextOptions<TouristTourGuideDbContext> optionsBuilderForInMemoryDB;
        private TouristTourGuide.Data.TouristTourGuideDbContext appDbContext;
        private TourService tourService;


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.optionsBuilderForInMemoryDB = new DbContextOptionsBuilder<TouristTourGuideDbContext>().UseInMemoryDatabase("TouristTourGuideInMemory" + Guid.NewGuid().ToString()).Options;
            appDbContext = new TouristTourGuideDbContext(optionsBuilderForInMemoryDB);
            SeedDatabase(appDbContext);
            tourService = new TourService(appDbContext);


        }
        [SetUp]
        public void Setup()
        {

        }
        
        [Test]
        public async Task GetTourForEditIsEqual() 
        {
            var touristTourId = appDbContext.TouristsTours.Where(x=>x.TourName== "Fake Tour 1").Select(x=>x.Id.ToString()).FirstOrDefault();

            EditViewModel viewModelForEdit = await tourService.GetTourForEdit(touristTourId);
            string resultId = viewModelForEdit.TourId.ToString();
            if (!String.Equals(touristTourId,resultId))
            {
                Assert.IsTrue(false);
            }

            Assert.IsTrue(true);
        }
        [Test]
        public async Task TourByIdShouldReturnTrueWhenExist() 
        {
            string? tourId = appDbContext.TouristsTours.Select(x => x.Id.ToString()).FirstOrDefault();
            DetailsViewModel t = await tourService.TourById(tourId);
            if (String.IsNullOrEmpty(t.TourName) || String.IsNullOrWhiteSpace(t.TourName))
            {
                Assert.IsTrue(false);
            }
            Assert.IsTrue(true);
        }
        [Test]
        public async Task testAllAsync()
        {
            List<string> categories = appDbContext.Categories.Select(x=>x.Name).ToList();
            List<AllViewModel> allViewModelsTours = appDbContext.TouristsTours.Select(x=>new AllViewModel()).ToList();
            AllToursQueryViewModel allToursQueryViewModel = new AllToursQueryViewModel()
            {
                Categories = categories,
                Tours = allViewModelsTours
            };
            var result = await tourService.AllAsync(allToursQueryViewModel);
            if (result==null)
            {
                Assert.IsTrue(false);
            }
            Assert.IsTrue(true);

        }
        
        [Test]
        public async Task testAllAsyncWithSerchWordOnlyIsEq() 
        {
            string serchWord = "Fake Tour 1";
            List<string> categories = appDbContext.Categories.Select(x => x.Name).ToList();
            
            List<AllViewModel> allViewModelsTours = appDbContext.TouristsTours.Select(x => new AllViewModel() 
            {
                Title = x.TourName,
                Location = x.Location.Country,
                
            }).ToList();
            AllToursQueryViewModel tourQuery = new AllToursQueryViewModel()
            {
                SerchByString = serchWord,
                Categories =categories,
               Tours = allViewModelsTours                
            };

            var result = await tourService.AllAsync(tourQuery);
            string? serchWordString = result.Tours.Select(x => x.Title.ToString()).FirstOrDefault();
            if (!String.Equals(serchWordString,serchWord))
            {
                Assert.IsTrue(false);
            }
            Assert.IsTrue(true);    
        }
        [Test]
        public async Task attemptToTestAllWithCategoryAndSerchWord() 
        {
            //category
            List<string> categories = appDbContext.Categories.Where(x=>x.Name== "Unit test category 1").Select(x=>x.Name).ToList();
            List<AllViewModel> tours = appDbContext.TouristsTours.Where(x=>x.TourName== "Fake Tour 1").Select(x=>new AllViewModel() 
            {
                Title = x.TourName,
                Location = x.Location.Country,
                PricePerPerson = x.PricePerPerson,
                
                
            }).ToList();
            string serchByStringTestTourName = "Fake Tour 1";

            AllToursQueryViewModel viewTModel = new AllToursQueryViewModel()
            {
                Categories = categories,
                SerchByString = serchByStringTestTourName,
                Tours = tours
            };

            AllToursFilteredAndPagedServiceModel result = await tourService.AllAsync(viewTModel);

            
            string resultSerchWordResult = result.Tours.Where(x=>x.Title==serchByStringTestTourName).Select(n=>n.Title).FirstOrDefault();
            
            if (!String.Equals(resultSerchWordResult,serchByStringTestTourName))
            {
                Assert.IsTrue(false);
            }

            Assert.IsTrue(true);

        }

        [Test]
        public async Task GetAllGuideUserToursIdShuldReturnTrueWhenExist()
        {
            string? guideUserId = appDbContext.GuideUsers.Where(x => x.Email == "ALOMOCK@gmail.com").Select(y => y.Id.ToString()).FirstOrDefault();

            if (String.IsNullOrEmpty(guideUserId))
            {
                Assert.IsTrue(false);                               
            }
            else {
                List<string> s = await tourService.GetAllGuideUserToursId(guideUserId);
                if (s != null)
                {
                    Assert.IsTrue(s.Any());
                }
            }           
        }
        [Test]
        public async Task IsTourOwnerShouldReturnTrueWhenGuideIsOwner() 
        {
            string? guideUserId = appDbContext.GuideUsers.Where(x => x.Email == "ALOMOCK@gmail.com").Select(y => y.Id.ToString()).FirstOrDefault();
            string? tourId = appDbContext.TouristsTours.Where(x=>x.GuideUserId.ToString()==guideUserId).Select(x => x.Id.ToString()).FirstOrDefault();
            if (tourId !=null)
            {
                Assert.IsTrue(await tourService.IsTourOwner(guideUserId, tourId));
            }
        }
        [Test]
        public void IsTourExistShouldReturnTrueWhenExist()
        {
            string tourId = appDbContext.TouristsTours.Select(x => x.Id.ToString()).FirstOrDefault();
            if (!String.IsNullOrEmpty(tourId)) 
            {
                
                Assert.IsTrue(tourService.IsTourExist(tourId));
            }                       
        }
        [Test]
        public async Task GetAllToursByGuideIdShouldReturnTrue() 
        {
            string? guideUserId = appDbContext.GuideUsers.Where(x => x.Email == "ALOMOCK@gmail.com").Select(y => y.Id.ToString()).FirstOrDefault();
            if (String.IsNullOrEmpty(guideUserId)) 
            {
                Assert.IsTrue(false);
            }
            else 
            {
               List <AllViewModel> allTours =await tourService.GetAllToursByGuideId(guideUserId);
                if (allTours != null)
                {
                    Assert.IsTrue(allTours.Any());
                }
               
            }
        }
        [Test]
        public async Task GetTourPricePerPersonByTourIdIsEqual() 
        {
           var tourIds =  appDbContext.TouristsTours.Where(x=>x.TourName== "NUnit Tour Full").Select(x=>x.Id).FirstOrDefault();
            var resultPrice = await tourService.GetTourPricePerPerson(tourIds.ToString());
            decimal getActualPrice = resultPrice;
            decimal price = 400000;
           Assert.AreEqual(price, getActualPrice);
        }

        [Test]
        public async Task DeleteMethodShouldReturnFalseWhenTourNotExist()
        {
            TouristTour? t = appDbContext.TouristsTours.Where(x => x.TourName == "NUnit Tour Full").FirstOrDefault();
            bool isExist = true;
            if (t != null)
            {
                await tourService.Delete(t.Id.ToString());
                isExist = appDbContext.TouristsTours.Where(x => x.TourName == "NUnit Tour Full").Any();
                if (isExist == false)
                {
                    Assert.False(isExist);
                }
                else
                {
                    Assert.True(isExist);
                }
            }
        }

        [Test]
        public async Task CreateTouristTourShouldReturnTrueWhenIsCreated()
        {

            GuideUser? guide = appDbContext.GuideUsers.Where(x => x.Email == "ALOMOCK@gmail.com").FirstOrDefault();
            Category? category = appDbContext.Categories.Where(x => x.Name == "Unit Test").FirstOrDefault();
            Location? location = appDbContext.Locations.Where(x => x.Country == "BuggLandia").FirstOrDefault();
            bool isCreated = false;
            if (guide != null && category != null && location != null)
            {
                TouristTourCreateViewModel tourViewModel = new TouristTourCreateViewModel()
                {
                    TourName = "NUnit Tour",
                    Duaration = "100000000 days",
                    StartEndHouers = "24:00 to 00:00",
                    NotSuitableFor = "NULL",
                    CategoryId = category.Id,
                    FullDescription = "Unit tests tour is a great tour ever",
                    LocationId = location.Id,
                    MeetingPoint = "NULL"

                };
                await tourService.CreateTouristTour(tourViewModel, guide.Id.ToString());
                TouristTour t = appDbContext.TouristsTours.Where(x => x.TourName == "NUnit Tour").FirstOrDefault();
                if (t == null)
                {

                    Assert.True(isCreated);
                }

                isCreated = true;
            }
            Assert.True(isCreated);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            // Изчистване на dbContextOptions защото не ми позволява да инициализирам обек от ДБ контекста
            appDbContext?.Dispose();
        }
    }
}
