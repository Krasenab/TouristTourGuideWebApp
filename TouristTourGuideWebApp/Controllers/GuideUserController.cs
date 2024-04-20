using Microsoft.AspNetCore.Mvc;
using TouristTourGuide.Infrastrucutre;
using TouristTourGuide.Services.Interfaces;
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
        public  IActionResult BecomeGuide()
        {
            string getAppUser = ClaimPrincipalExtensions.GetCurrentUserId(this.User);

            if (!_guideUserService.isUserGuide(getAppUser))
            {
                //TODO add toast 
                return RedirectToAction("Index", "Home");
            }


            
            return View();
        }
    }
}
