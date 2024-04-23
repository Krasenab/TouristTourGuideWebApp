using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public Task BookingsDetails()
        {
            throw new NotImplementedException();
        }

        public async Task CreateBooking(CreateBookingViewModel viewModel)
        {
            TouristTourBooking b = new TouristTourBooking()
            {
                CountOfPeople = viewModel.CountOfPeople,
                ApplicationUserId = Guid.Parse(viewModel.ApplicationUserId),
                TouristTourId = Guid.Parse(viewModel.TouristTourId)
            };

            await _db.TouristTourBookings.AddAsync(b);
            await _db.SaveChangesAsync();
        }
    }
}
