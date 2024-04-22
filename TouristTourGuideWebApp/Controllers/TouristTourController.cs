using Azure.Identity;
using Microsoft.AspNetCore.Mvc;
using TouristTourGuide.Infrastrucutre;
using TouristTourGuide.Services.Interfaces;
using TouristTourGuide.ViewModels.AppImageViewModels;
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
        private readonly IImageService _imageServie;
        private readonly IVoteService _voteService;

        public TouristTourController(ITourService tourService, ILocationService locationService
            , ICategoryService categoryService, IGuideUserService guideUserService, IImageService imageServie,
            IVoteService voteService)
        {
            this._tourService = tourService;
            this._locationService = locationService;
            this._categoryService = categoryService;
            this._guideUserService = guideUserService;
            this._imageServie = imageServie;
            this._voteService = voteService;

        }

        public async Task<IActionResult> All([FromQuery] AllToursQueryViewModel queryModel)
        {
            
            AllToursFilteredAndPagedServiceModel serviceModel = await _tourService.AllAsync(queryModel);

            queryModel.Tours = serviceModel.Tours;
            
            var categories =  _categoryService.GetAllCategories();
            var convertToString = categories.ConvertAll<string>(x => x.Name);            
            queryModel.Categories = convertToString;
            
            return View(queryModel);
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
            _tourService.CreateTouristTour(model, guideUserId);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string Id)
        {
            var editViewModel = await _tourService.GetTourForEdit(Id);
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

                _locationService.CreateCityCountry(locationId, editViewModel.LocationCity);
            }
            _tourService.EditTour(editViewModel);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id) 
        {
         
            var detailsViewModel = await _tourService.TourById(id);
            if (_tourService.isHavePictures(id))
            {
                var uniqFileName = await _imageServie.TourImageUniqueName(id);
                detailsViewModel.AllTourApplicationImages = _imageServie.GetImagesFilesMongoDb(uniqFileName);
            }
          
            
            return View(detailsViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddImage(string tourId, IFormFile imageFile)
        {
            bool isValid = _imageServie.IsFileExtensionValid(imageFile);


            if (!isValid)
            {
                return BadRequest("Invalid image extension");
            }
            if (imageFile ==null && imageFile.Length <=0) 
            {
                //TODO: add toast message for invalid fail 
                return Ok();
            }

            await _imageServie.AddTourImage(tourId, imageFile, ClaimPrincipalExtensions.GetCurrentUserId(this.User));
            string uniqueFileName = await _imageServie.TourImageUniqueName(tourId);
            await _imageServie.AddImageFileToMongoDb(imageFile,uniqueFileName);
            

            return RedirectToAction("Details", "TouristTour", new {id=tourId });
        }

    }
}
