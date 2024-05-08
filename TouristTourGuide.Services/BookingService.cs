using Microsoft.EntityFrameworkCore;
using TouristTourGuide.Data;
using TouristTourGuide.Data.Models.Sql.Models;
using TouristTourGuide.Services.Interfaces;
using TouristTourGuide.ViewModels.BookingViewModels;

namespace TouristTourGuide.Services
{
    public class BookingService : IBookingService
    {
        private readonly TouristTourGuideDbContext _db;
        public BookingService(TouristTourGuideDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task AcceptBooking(string bookingId)
        {            
            var b = await _db.TouristTourBookings.Where(x => x.Id.ToString() == bookingId).FirstOrDefaultAsync();
            //add if(b!=null) on 4/25/2024 
            if (b!=null)
            {
                if (b.isAccepted==true)
                {
                    b.isAccepted = false;
                }
                else
                {
                    b.isAccepted=true;
                }
            }
            bool check = b.isAccepted;
            
            await _db.SaveChangesAsync();
        }

        public async Task<List<BookingDetailsViewModel>> BookingsDetails(string tourId)
        {
            var bookings = await _db.TouristTourBookings.Where(t => t.TouristTourId.ToString() == tourId)
                .Select(x => new BookingDetailsViewModel()
                {
                    Id = x.Id.ToString(),
                    TourName = x.TouristTour.TourName,
                    PhoneNumber = x.PhoneNumber,
                    Email = x.Email,
                    CountOfPeople = x.CountOfPeople,
                    BookingDate = x.BookedDate.ToString(),
                    // и това забравих да добавя преди 4/25/2024 тоест не го добвих на 4/23/2024
                    isAccepted = x.isAccepted,
                    AppUserId = x.ApplicationUser.FirstName + x.ApplicationUser.LastName

                }).ToListAsync();
            return bookings;
        }

        public async Task CreateBooking(CreateBookingViewModel viewModel)
        {            
            
            TouristTourBooking b = new TouristTourBooking()
            {
                CountOfPeople = viewModel.CountOfPeople,
                ApplicationUserId = Guid.Parse(viewModel.ApplicationUserId),
                TouristTourId = Guid.Parse(viewModel.TouristTourId),
                Email = viewModel.Email,
                PhoneNumber= viewModel.PhoneNumber               
            };

            await _db.TouristTourBookings.AddAsync(b);
            await _db.SaveChangesAsync();
        }



        //добавям този метод на 4/25/2024 
        public async Task<List<AcceptOrRefuseViewModel>> GetAcceptedTourBookings(string userGuideId)
        {
            var tB = await _db.TouristTourBookings.Where(x => x.TouristTour.GuideUserId.ToString() == userGuideId)
                .Select(x => new AcceptOrRefuseViewModel()
                {
                    TourName = x.TouristTour.TourName,
                    
                    
                }).Distinct().ToListAsync();

            return tB;
        }

        public Task<List<AllBookingViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<AllBookingViewModel>> GetAll(List<string> ToursIds)
        {
            throw new NotImplementedException();
        }

        public async Task RefuseBooking(string bookingId)
        {
            var b = await _db.TouristTourBookings.Where(x=>x.Id.ToString()==bookingId)
                .FirstOrDefaultAsync();
            if (b==null)
            {
                throw new NullReferenceException("booking null");
            }
            b.isAccepted = false;
            
        }
    }
}
