using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TouristTourGuide.Infrastrucutre;
using TouristTourGuide.Services.Interfaces;
using TouristTourGuide.ViewModels.GuideUserViewModels;
using static TouristTourGuide.Infrastrucutre.ClaimPrincipalExtensions;

namespace TouristTourGuideWebApp.Controllers
{
    public class GuideUserController : Controller
    {
        private IGuideUserService _guideUserService;
        public GuideUserController(IGuideUserService guideUserService)
        {
            _guideUserService = guideUserService;
        }

        [HttpGet]
        public IActionResult BecomeGuide()
        {
            string getAppUser = ClaimPrincipalExtensions.GetCurrentUserId(this.User);

            if (_guideUserService.isUserGuide(getAppUser))
            {
                //TODO add toast 
                return RedirectToAction("Index", "Home");
            }

            BecomeGuideUserViewModel view = new BecomeGuideUserViewModel();

            return View(view);
        }

        [HttpPost]
        public async Task<IActionResult> BecomeGuide(BecomeGuideUserViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }


            string getUser = ClaimPrincipalExtensions.GetCurrentUserId(this.User);
            await _guideUserService.CreateGuide(viewModel, getUser);

            return RedirectToAction("Index", "Home");
        }
    }
}
