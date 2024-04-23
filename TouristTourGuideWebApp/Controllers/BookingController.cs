using Microsoft.AspNetCore.Mvc;

namespace TouristTourGuideWebApp.Controllers
{
    public class BookingController : Controller
    {
        public BookingController()
        {
                
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
