using Microsoft.AspNetCore.Mvc;
using TouristTourGuide.Infrastrucutre;
using TouristTourGuide.Services;
using TouristTourGuide.Services.Interfaces;
using TouristTourGuideWebApp.Areas.Admin.ViewModel;

namespace TouristTourGuideWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TouristTourController : BaseAdminController
    {
        private readonly ITourService _tourService;
        private readonly IGuideUserService _guideUserService;
        public TouristTourController(ITourService tourService, IGuideUserService guideUserService)
        {
            this._tourService = tourService;
            this._guideUserService = guideUserService;
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

            return View(model);
        }
    }
}
