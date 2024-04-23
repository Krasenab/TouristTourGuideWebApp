using Microsoft.AspNetCore.Mvc;
using TouristTourGuide.Infrastrucutre;
using TouristTourGuide.Services.Interfaces;
using TouristTourGuide.ViewModels.BookingViewModels;
using static TouristTourGuide.Infrastrucutre.ClaimPrincipalExtensions;

namespace TouristTourGuideWebApp.Controllers
{
    public class BookingController : Controller
    {
       private readonly IBookingService _bookingService;
        private readonly ITourService _tourService;
        public BookingController(IBookingService bookingService,ITourService tourServie)
        {
            _bookingService = bookingService;
            _tourService = tourServie;
        }
        [HttpGet]
        public  IActionResult Create()
        {
            CreateBookingViewModel bookingViewModel = new CreateBookingViewModel();
          
            return View(bookingViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBookingViewModel bookingViewModel)
        {
            string userId = ClaimPrincipalExtensions.GetCurrentUserId(this.User);
            bookingViewModel.ApplicationUserId = userId;
            await _bookingService.CreateBooking(bookingViewModel);
            
            return RedirectToAction("Index", "Home");   
        }
        
    }
}
