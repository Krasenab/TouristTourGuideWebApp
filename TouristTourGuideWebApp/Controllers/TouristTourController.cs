using Azure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TouristTourGuide.Infrastrucutre;
using TouristTourGuide.Services.Interfaces;
using TouristTourGuide.ViewModels.AppImageViewModels;
using TouristTourGuide.ViewModels.TouristTourViewModels;
using static TouristTourGuide.Infrastrucutre.ClaimPrincipalExtensions;
using static TouristTourGuide.Common.NotificationMessage;
using TouristTourGuide.Common;


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
        private readonly ICommentsService _commentsService;
        private readonly IBookingService _bookingService;

        public TouristTourController(ITourService tourService, ILocationService locationService
            , ICategoryService categoryService, IGuideUserService guideUserService, IImageService imageServie,
            IVoteService voteService, ICommentsService commentsService,
            IBookingService bookingService)
        {
            this._tourService = tourService;
            this._locationService = locationService;
            this._categoryService = categoryService;
            this._guideUserService = guideUserService;
            this._imageServie = imageServie;
            this._voteService = voteService;
            this._commentsService = commentsService;
            this._bookingService = bookingService;
        }

        [HttpPost]
        
        public async Task<IActionResult> DeletePicture(string uniqueName)
        {
            var metadataImage = await _imageServie.AppImageInfo(uniqueName);
            await _imageServie.DelateImageByUniqName(metadataImage.FileName);
            List<string> name = new List<string>();
            name.Add(metadataImage.FileName);
            _imageServie.DeleteManyTourImageFileMongoDb(name);

            return RedirectToAction("Details", new { id = metadataImage.TouristTourId });
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Delete(string tourId)
        {
            //добавил съм го на 4/26/2024
            if (!_tourService.IsTourExist(tourId))
            {
                TempData[ErrorMassage] = "Tour does not exist or has been removed";
                RedirectToAction("All", "Tour");
            }

            string userId = ClaimPrincipalExtensions.GetCurrentUserId(this.User);
            if (!_guideUserService.isUserGuide(userId) && !this.User.IsAdmin()) 
            {
                TempData[WarningMassage] = "You must be owner of the tour or Admin...Hmmm how you get here";
                RedirectToAction("All", "TouristTour");
            }
           
            List<string> listOfImagesName = await _imageServie.GetAllTourUniqNameImages(tourId);
            _imageServie.DeleteManyTourImageFileMongoDb(listOfImagesName);

            var isHaveComments = await _commentsService.GetAllComentAsync(tourId);
            if (isHaveComments != null)
            {
                _commentsService.DeleteTourComments(tourId);
            }
            if (_tourService.isHavePictures(tourId))
            {
                _imageServie.DeleteTourImagesSql(tourId);
            }
            int votess = await _voteService.CountVoteByTourIdAsync(tourId);
            if (votess != 0)
            {
                _voteService.DeleteAllTourVote(tourId);
            }

            await _tourService.Delete(tourId);

            return RedirectToAction("All", "TouristTour");
        }
        public async Task<IActionResult> All([FromQuery] AllToursQueryViewModel queryModel)
        {
            AllToursFilteredAndPagedServiceModel serviceModel = await _tourService.AllAsync(queryModel);

            queryModel.Tours = serviceModel.Tours;

            var categories = _categoryService.GetAllCategories();
            var convertToString = categories.ConvertAll<string>(x => x.Name);
            queryModel.Categories = convertToString;

            return View(queryModel);
        }


        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            string userId = ClaimPrincipalExtensions.GetCurrentUserId(this.User);

            bool isUserGuide = _guideUserService.isUserGuide(userId);
            
            if (!isUserGuide && !this.User.IsAdmin())
            {
                TempData[ErrorMassage] = "You must be supplier to can create some tour";
                return RedirectToAction("Index", "Home");
            }

            TouristTourCreateViewModel model = new TouristTourCreateViewModel()
            {
                Locations = _locationService.GetAllLocations(),
                Categories = _categoryService.GetAllCategories()

            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TouristTourCreateViewModel model)
        {
            
            //if (!ModelState.IsValid) 
            //{
            //    return View(model);
            //}
            string userId = this.User.GetCurrentUserId();
            string guideUserId = _guideUserService.GuidUserId(userId);
            int? locationId = model.LocationId;
            _locationService.CreateCityCountry((int)locationId, model.LocationCity);
            await _tourService.CreateTouristTour(model, guideUserId);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string Id)
        {
            if (!_tourService.IsTourExist(Id))
            {

                TempData[WarningMassage] = "This tour does not exist or has been removed";
                return RedirectToAction("Index", "Home");
            }

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
        [Authorize]
        public async Task<IActionResult> Details(string id)
        {
            if (!_tourService.IsTourExist(id))
            {
                this.TempData[WarningMassage] = "This tour does not exist or have been removed";
                return RedirectToAction("All", "Tourist");
            }
            var detailsViewModel = await _tourService.TourById(id);
            if (_tourService.isHavePictures(id))
            {
                //var uniqFileName = await _imageServie.TourImageUniqueName(id);
                //detailsViewModel.AllTourApplicationImages = _imageServie.GetImagesFilesMongoDb(uniqFileName);
                var names = await _imageServie.GetAllTourUniqNameImages(id);
                detailsViewModel.AllTourApplicationImages = _imageServie.GetAllImagesFileByListOfUniqueName(names);
            }

            detailsViewModel.TourRatign = await _voteService.CalculateRatingAsync(id);
            detailsViewModel.Comments = await _commentsService.GetAllComentAsync(id);
            foreach (var singleComment in detailsViewModel.Comments)
            {
                string appUserId = singleComment.AppUserId;
                var imageData = await _imageServie.GetAppUserImageFileUniqueNameSQL(appUserId);
                singleComment.AppUserProfilePicture =  _imageServie.GetImageBytesMongoDb(imageData);
            }
            detailsViewModel.VoteCount = await _voteService.CountVoteByTourIdAsync(id);


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
            if (imageFile == null && imageFile.Length <= 0)
            {
                //TODO: add toast message for invalid fail 
                return Ok();
            }

            string filename = await _imageServie.AddTourImage(tourId, imageFile, ClaimPrincipalExtensions.GetCurrentUserId(this.User));
            await _imageServie.AddImageFileToMongoDb(imageFile, filename);


            return RedirectToAction("Details", "TouristTour", new { id = tourId });
        }

        [Authorize]
        public async Task<IActionResult> TourBookings(string tourId)
        {
            if (!_tourService.IsTourExist(tourId))
            {
                return StatusCode(404);
            }

            var tour = await _tourService.GetTourForEdit(tourId);
            string name = tour.TourName;

            var getBookings = await _bookingService.BookingsDetails(tourId);
            TourWithBookingsViewModel viewModel = new TourWithBookingsViewModel()
            {
                Id = tourId,
                TourName = name,
                TourBookings = getBookings
            };


            return View(viewModel);
        }

        [HttpPost]
        public IActionResult DeleteTourPicture(string uniqueName, string tourId)
        {
            if (!_tourService.IsTourExist(tourId))
            {
                return Content("Somehting get wrong!!");
            }

            string removedPictureName = _imageServie.DeleteOneImageSql(uniqueName, tourId);
            _imageServie.DeleteOneImageFileMDB(removedPictureName);

            return Content("success");
        }

        [HttpGet]
        public async Task<IActionResult> MyTours() 
        {
            string thisUser = ClaimPrincipalExtensions.GetCurrentUserId(this.User);           
            string guideUserId = _guideUserService.GuidUserId(thisUser);
            if (guideUserId ==null) 
            {
                this.TempData[WarningMassage] = "You must be tour guide";
                return RedirectToAction("Index", "Home");
            }
            AllMyToursVIewModel model = new AllMyToursVIewModel()
            {
                MyTours = await _tourService.GetAllToursByGuideId(guideUserId)
            };
            return View(model);
        }

    }
}
