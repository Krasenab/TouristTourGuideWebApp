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
            b.isAccepted = true;
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
                    BookingDate = x.BookedDate.ToString()

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
                PhoneNumber= viewModel.PhoneNumber,
               
            };

            await _db.TouristTourBookings.AddAsync(b);
            await _db.SaveChangesAsync();
        }

     

    }
}
