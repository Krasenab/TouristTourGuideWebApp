using Microsoft.AspNetCore.Mvc;
using TouristTourGuide.Infrastrucutre;
using TouristTourGuide.Services;
using TouristTourGuide.Services.Interfaces;
using TouristTourGuide.ViewModels.AppImageViewModels;
using TouristTourGuideWebApp.Areas.Admin.ViewModel;

namespace TouristTourGuideWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TouristTourController : BaseAdminController
    {
        private readonly ITourService _tourService;
        private readonly IGuideUserService _guideUserService;
        private readonly IImageService _imageService;
        public TouristTourController(ITourService tourService, IGuideUserService guideUserService,
            IImageService imageService)
        {
            this._tourService = tourService;
            this._guideUserService = guideUserService;
            this._imageService = imageService;
        }
        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            string appUserId = ClaimPrincipalExtensions.GetCurrentUserId(this.User);
            string guideUserId = _guideUserService.GuidUserId(appUserId);


            MyToursViewModel model = new MyToursViewModel()
            {
                ExistingTours = await _tourService.GetAllToursByGuideId(guideUserId)
            };

            foreach (var m in model.ExistingTours)
            {
                var uniqueName = await _imageService.TourImageUniqueName(m.Id);
                if (uniqueName == null) 
                {
                    continue;
                }
                var img = _imageService.GetImageBytesMongoDb(uniqueName);

                AppImagesViewModel imgViewModel = new AppImagesViewModel()
                {
                    ApplicationUserId = appUserId,
                    TouristTourId = m.Id,
                    FileName = uniqueName,
                    FileData = img,
                    UniqueFileName = uniqueName
                };
                m.TourImage = imgViewModel;
            }
            return View(model);
        }
    }
}
