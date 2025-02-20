using Microsoft.EntityFrameworkCore;
using TouristTourGuide.Data;
using TouristTourGuide.ViewModels.TouristTourViewModels;
using static TouristTourGuide.Services.NUTests.DbMockSeedData;
using TouristTourGuide.Data.Models.Sql.Models;
using TouristTourGuide.ViewModels.BookingViewModels;
using MongoDB.Bson;

namespace TouristTourGuide.Services.NUTests
{
    public class BookingServiceTests
    {
        private DbContextOptions<TouristTourGuideDbContext> optionsBuilderForInMemoryDB;
        private TouristTourGuide.Data.TouristTourGuideDbContext appDbContext;

        private BookingService bookingService;
        private TourService tourServices;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.optionsBuilderForInMemoryDB = new DbContextOptionsBuilder<TouristTourGuideDbContext>().UseInMemoryDatabase("TouristTourGuideInMemory" + Guid.NewGuid().ToString()).Options;
            appDbContext = new TouristTourGuideDbContext(optionsBuilderForInMemoryDB);
            SeedDatabase(appDbContext);

            bookingService= new BookingService(appDbContext);


        }
        [SetUp]
        public void Setup()
        {

        }
        [Test]
        public async Task BookingsDetailsByTourIdShouldBeEqual() 
        {
            BookingDetailsViewModel? expected = appDbContext.TouristTourBookings.Where(x => x.TouristTour.TourName == "Fake Tour 1").Select(x => new BookingDetailsViewModel()
            {
                Id = x.Id.ToString(),
                
                 
            }).FirstOrDefault();

            string? expectedBookingId = expected.Id;

            string? tourId = appDbContext.TouristsTours.Where(x=>x.TourName=="Fake Tour 1").Select(id=>id.Id.ToString()).FirstOrDefault();

           List<BookingDetailsViewModel> actual = await bookingService.BookingsDetails(tourId);
            string actualBookingId = actual.Where(x=>x.TourName=="Fake Tour 1").Select(id=>id.Id).FirstOrDefault();

           Assert.AreEqual(expectedBookingId, actualBookingId); 
            
        }
        [Test]
        public async Task GetAccpetedTourBookingsShouldBeEqual() 
        {
            string? gUserId = appDbContext.GuideUsers.Where(x=>x.Name== "FAKE GUIDE").Select(x=>x.Id.ToString()).FirstOrDefault();

            List<AcceptOrRefuseViewModel> getFakeData = appDbContext.TouristTourBookings.Select(x=>new AcceptOrRefuseViewModel() 
            {
                GuideUserId = x.GuideUserId,
                TourName = x.TouristTour.TourName,
                
            }).ToList();

            int countFakeData = getFakeData.Count;
           
            var b = await bookingService.GetAcceptedTourBookings(gUserId);
            int actual = b.Count;
            Assert.AreEqual(actual, countFakeData);          
        }
        [Test]
        public async Task AcceptBookingShouldReturnTrueWhenIsAccepted()
        {
            bool isAccept = true;
            string? bookingId = appDbContext.TouristTourBookings.Where(x=>x.TouristTour.TourName=="Fake Tour 1").Select(id=>id.Id.ToString()).FirstOrDefault();
            bookingService.AcceptBooking(bookingId);

            BookingDetailsViewModel? b = appDbContext.TouristTourBookings.Where(x => x.TouristTour.TourName == "Fake Tour 1")
                .Select(b=>new BookingDetailsViewModel() 
                {
                    TourName = b.TouristTour.TourName,
                    AppUserId = b.ApplicationUserId.ToString(),
                    BookingDate = b.BookedDate.ToString(),
                    isAccepted = b.isAccepted,
                    Id = b.Id.ToString(),
                    CountOfPeople = b.CountOfPeople,
                    Email = b.Email,
                    PhoneNumber = b.PhoneNumber
                    
                })
                .FirstOrDefault();

            if (b.isAccepted==false)
            {
                Assert.IsTrue(false);
            }
            Assert.IsTrue(true);
        }
        [Test]
        public async Task GetAllByBookedDateAndPeopleCountShouldBeEqual()
        {
            var allBokingTourViewModel = appDbContext.TouristTourBookings.Select(x => new AllBookingViewModel()
            {
                Id = x.Id.ToString(),
                TourName = x.TouristTour.TourName,
                TourId = x.TouristTourId.ToString(),
                BookingDate = x.BookedDate.ToString(),
                CountOfPeople = x.CountOfPeople
            }).ToList();
            AllBokingQueryViewModel viewModel = new AllBokingQueryViewModel()
            {
                // remove g.id and start worked 
                AllBookedTour = allBokingTourViewModel.Count(),
                AllToursWithBooking = allBokingTourViewModel,
               // SerchByString = "Fake Tour 1"
            };
            AllBookingFilteredAndPagedServiceViewModel allBookingFilteredAndPagedServiceViewModel = await bookingService.GetAll(viewModel);
            var dateAsStr = "1/17/2025";
            int coutOfPeople = 1;

            string actualDateAsStr = allBookingFilteredAndPagedServiceViewModel.AllBokings.Select(x => x.BookingDate).FirstOrDefault();
            string shortActualDateAsStr = actualDateAsStr.Substring(0, 9);
            int actualCountOfPeople = allBokingTourViewModel.Where(x => x.CountOfPeople == 1).Select(c => c.CountOfPeople).FirstOrDefault();

            int zeroPoint = 0;

            Assert.AreEqual(coutOfPeople, actualCountOfPeople);
           // Assert.AreEqual(actualDateAsStr,dateAsStr);
            
           
        }

        [Test]
        public async Task GetAllBySearchByStringShouldBeEqual() 
        {
           // GuideUser? g = appDbContext.GuideUsers.Where(n => n.Name == "FAKE GUIDE").FirstOrDefault();
            var allBokingTourViewModel = appDbContext.TouristTourBookings.Select(x => new AllBookingViewModel()
            {
                Id = x.Id.ToString(),
                TourName = x.TouristTour.TourName,
                TourId = x.TouristTourId.ToString(),
                BookingDate = x.BookedDate.ToString(),
                CountOfPeople = x.CountOfPeople
            }).ToList();
            AllBokingQueryViewModel viewModel = new AllBokingQueryViewModel()
            {
                // remove g.id and start worked 
                AllBookedTour = allBokingTourViewModel.Count(),
                AllToursWithBooking = allBokingTourViewModel,
                SerchByString = "Fake Tour 1"

            };
            
            AllBookingFilteredAndPagedServiceViewModel filtered = await bookingService.GetAll(viewModel);
            AllBookingViewModel? actualResult = filtered.AllBokings.Where(n=>n.TourName=="Fake Tour 1").FirstOrDefault();
            string getResultString = actualResult.TourName;
            string tourNameExpected = "Fake Tour 1";
            string stopper = "";
           Assert.AreEqual(actualResult.TourName, tourNameExpected);  
        }
        [Test]
        public async Task GetAllReturnTrueWhenGetAllBokedTours() 
        {

            GuideUser? g = appDbContext.GuideUsers.Where(n => n.Name == "FAKE GUIDE").FirstOrDefault();
            var allBokingTourViewModel = appDbContext.TouristTourBookings.Select(x=>new AllBookingViewModel() 
            {
                Id = x.Id.ToString(),
                TourName = x.TouristTour.TourName,
                TourId = x.TouristTourId.ToString(),
                BookingDate = x.BookedDate.ToString(),
                CountOfPeople = x.CountOfPeople,

               
                
            }).ToList();
            AllBokingQueryViewModel viewModel = new AllBokingQueryViewModel()
            {
                // remove g.id and start worked 
                AllBookedTour = allBokingTourViewModel.Count(),
                AllToursWithBooking = allBokingTourViewModel

            };
           
            AllBookingFilteredAndPagedServiceViewModel filter = await bookingService.GetAll(viewModel);
            if (filter ==null)
            {
                Assert.IsTrue(false);
            }
            Assert.IsTrue(true);

        }
        [Test]
        public void CreateBookingShouldReturnTrueWehenWork() 
        {
            


            ApplicationUser appUser1 = appDbContext.ApplicationUsers.Where(x=>x.FirstName== "TestPerson").First();
            TouristTour tour = appDbContext.TouristsTours.Where(x=>x.TourName== "NUnit Tour Full").First();
            CreateBookingViewModel create = new CreateBookingViewModel()
            {
                ApplicationUserId = appUser1.Id.ToString(),
                Email = "personSecondMail@gmaill.com",
                PhoneNumber = "00011122",
                TouristTourId = tour.Id.ToString(),
                CountOfPeople = 1,
                BookedDate = DateTime.Now,
            };

             bookingService.CreateBooking(create);

            bool isExist = appDbContext.TouristTourBookings.Where(x => x.Email == "personSecondMail@gmaill.com").Any();

            if (!isExist)
            {
                Assert.IsTrue(isExist);
            }
            Assert.IsTrue(isExist);



        }
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            // Изчистване на dbContextOptions защото не ми позволява да инициализирам обекT от ДБ контекста
            appDbContext?.Dispose();
        }
    }
}
