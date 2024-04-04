using Microsoft.AspNetCore.Mvc;
using TouristTourGuide.Services;
using Nager.Country;

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
