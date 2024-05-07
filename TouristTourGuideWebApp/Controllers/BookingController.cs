using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging.Signing;
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
        public async  Task<IActionResult> Create(string tourId)
        {
            //add 4/25/2024 not woriking before this date: бях забравил да добавя string tourId и за това не разботише правилно :@ 
            CreateBookingViewModel bookingViewModel = new CreateBookingViewModel();
            bookingViewModel.TouristTourId = tourId;
            //add 4/29/2024
            bookingViewModel.PricePerPerson = await _tourService.GetTourPricePerPerson(tourId);
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

        //добавям го на 4/25/2024 1:59
     
        [HttpPost]
        public async Task<IActionResult> AcceptOrRefuse([FromBody]BookingDetailsViewModel bookingDetails)
        {

            await _bookingService.AcceptBooking(bookingDetails.Id);
            return Json(new {
                succsess=true,
                message="Succsesfully change status"

            });
            
        }
        [HttpGet]
        public async Task<IActionResult> AcceptedBookings(string guideUserId) 
        {
            var acceptedTourBookings = await _bookingService.GetAcceptedTourBookings(guideUserId);

            return View(acceptedTourBookings);
        }

    }
}
