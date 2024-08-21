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
            if (this.User.IsInRole("Administrator"))
            {
               return  RedirectToAction("Index", "Home", new { Area = "Admin" });
            }
            var pageImages = _imageService.GetIndexPageImageMongoDb();
            PageImageViewModel pageImageViewModel = new PageImageViewModel();
            pageImageViewModel.PageImages = pageImages.Where(x => x.CustomUniqeFileName == "Ahnali people" || x.CustomUniqeFileName == "streetIndexView" ||x.CustomUniqeFileName== "beatefulPlace" || String.IsNullOrEmpty(x.CustomUniqeFileName)).ToList();
            return View(pageImageViewModel);
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
