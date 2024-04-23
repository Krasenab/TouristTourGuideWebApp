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
        Task CreateBooking(CreateBookingViewModel viewModel,string tourId);
        Task<List<BookingDetailsViewModel>> BookingsDetails(string tourId);
        Task AcceptBooking(string bookingId);
     
    }
}
