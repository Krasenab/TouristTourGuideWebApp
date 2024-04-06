using Microsoft.AspNetCore.Mvc;
using TouristTourGuide.Infrastrucutre;
using TouristTourGuide.Services;
using TouristTourGuide.Services.Interfaces;
using TouristTourGuide.ViewModels;
using static TouristTourGuide.Infrastrucutre.ClaimPrincipalExtensions;


namespace TouristTourGuideWebApp.Controllers
{
    public class TouristTourController : Controller
    {
        private readonly ITourService _tourService;
        private readonly ILocationService _locationService;
        private readonly ICategoryService _categoryService;
        private readonly IGuideUserService _guideUserService;
        public TouristTourController(ITourService tourService,ILocationService locationService
            ,ICategoryService categoryService,IGuideUserService guideUserService)
        {
                this._tourService = tourService;
                this._locationService = locationService;
                this._categoryService = categoryService;
                this._guideUserService = guideUserService;
        }

        [HttpGet]
        public IActionResult Create()
        {
         
           
            TouristTourCreateViewModel model = new TouristTourCreateViewModel()
            {
                Locations = _locationService.GetAllLocations(),
                Categories = _categoryService.GetAllCategories()
        
            };
            return View(model);
        }
       
        [HttpPost]
        public  IActionResult Create(TouristTourCreateViewModel model) 
        {
            //string getGuidUserId = _guideUserService.GuidUserId(ClaimPrincipalExtensions.GetCurrentUserId(this.User));
            string userId = this.User.GetCurrentUserId();
            string guideUserId = _guideUserService.GuidUserId(userId);
            _tourService.CreateTouristTour(model,guideUserId);
            return RedirectToAction ("Index", "Home");
        }

    }
}
