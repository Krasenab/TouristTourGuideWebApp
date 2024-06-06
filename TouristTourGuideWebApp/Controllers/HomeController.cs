using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TouristTourGuide.Services.Interfaces;
using TouristTourGuide.ViewModels;
using TouristTourGuide.ViewModels.ApplicationImageViewModels;


namespace TouristTourGuideWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IImageService _imageService;

        public HomeController(ILogger<HomeController> logger, IImageService imageService)
        {
            _logger = logger;
            _imageService = imageService;
        }

        public IActionResult Index()
        {           
            return View();
        }      
        public IActionResult Privacy()
        {
            return View();
        }
       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id?? HttpContext.TraceIdentifier });
        }
    }
}
