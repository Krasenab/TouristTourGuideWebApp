using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristTourGuide.ViewModels.BookingViewModels;

namespace TouristTourGuide.Services.Interfaces
{
    public interface IBookingService
    {
        Task CreateBooking(CreateBookingViewModel viewModel);
        Task<List<BookingDetailsViewModel>> BookingsDetails(string tourId);
        Task AcceptBooking(string bookingId);
        // Add Refu method on 4/24/2024
        Task<List<AcceptOrRefuseViewModel>> GetAcceptedTourBookings(string userGuideId);        
        Task UserBookingStatus(string appUser);
        Task<AllBookingFilteredAndPagedServiceViewModel> GetAll(AllBokingQueryViewModel queryViewModel);
        
     
    }
}
