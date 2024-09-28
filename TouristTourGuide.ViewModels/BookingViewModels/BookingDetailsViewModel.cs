using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristTourGuide.ViewModels.AppImageViewModels;
using TouristTourGuide.ViewModels.ApplicationImageViewModels;

namespace TouristTourGuide.ViewModels.BookingViewModels
{
    public class BookingDetailsViewModel
    {
        public string Id { get; set; }
        public string TourName { get; set; }
        public string AppUserId { get; set; }
        public bool isAccepted { get; set;}
        public int CountOfPeople { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string BookingDate { get; set; }
    }
}
