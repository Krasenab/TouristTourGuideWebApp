using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using TouristTourGuide.Services.Interfaces;
using TouristTourGuideWebApp.Areas.Admin.ViewModel.AppUserViewModels;

namespace TouristTourGuideWebApp.Areas.Admin.Controllers
{
    public class AppUserController : BaseAdminController
    {
        private readonly IAppUserService _appUserService;
        public AppUserController(IAppUserService appUserService)
        {
           this._appUserService = appUserService;
        }

        [HttpGet]
        public async Task<IActionResult> AllUser()
        {
            AllUserViewModel model = new AllUserViewModel()
            {
                AllUsersList = await _appUserService.GetAllUserAsync()
            };            
            return View(model);
        }
    }
}
