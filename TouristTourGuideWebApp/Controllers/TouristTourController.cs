using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TouristTourGuide.Infrastrucutre;
using TouristTourGuide.Services.Interfaces;
using TouristTourGuide.ViewModels.LocationViewModels;
using TouristTourGuide.ViewModels.TouristTourViewModels;
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
        public IActionResult Create(TouristTourCreateViewModel model) 
        {
          
            string userId = this.User.GetCurrentUserId();
            string guideUserId = _guideUserService.GuidUserId(userId);

            _locationService.CreateCityCountry(model.LocationId, model.LocationCity);
            _tourService.CreateTouristTour(model,guideUserId);

            return RedirectToAction ("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string Id)
        {
             var  editViewModel = await _tourService.GetTourForEdit(Id);
             editViewModel.LocationCity = await _locationService.GetTourCity(Id);      
             editViewModel.Categories = _categoryService.GetAllCategories();
             editViewModel.Locations = _locationService.GetAllLocations();
         
           
            return View(editViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditViewModel editViewModel)
        {
           
            if (!_locationService.isCountryCityExist(editViewModel.LocationId, editViewModel.LocationCity))
            {
                int locationId = editViewModel.LocationId ?? 0; // if editViewModel.LocationId is null set 0 this is bcouse prop in my view model is type int?

                _locationService.CreateCityCountry(locationId ,editViewModel.LocationCity);
            }
            _tourService.EditTour(editViewModel);

            return RedirectToAction("Index", "Home");
        }

    }
}
