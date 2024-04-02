using Microsoft.AspNetCore.Mvc;
using TouristTourGuide.Services;
using TouristTourGuide.Services.Interfaces;

namespace TouristTourGuideWebApp.Controllers
{
    public class TouristTourController : Controller
    {
        private TourService _tourService;
        
        public TouristTourController(TourService tourService)
        {
                this._tourService = tourService;
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
    }
}
