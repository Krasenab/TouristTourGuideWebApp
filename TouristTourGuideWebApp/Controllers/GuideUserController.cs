using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TouristTourGuide.Infrastrucutre;
using TouristTourGuide.Services.Interfaces;
using TouristTourGuide.ViewModels.GuideUserViewModels;
using static TouristTourGuide.Infrastrucutre.ClaimPrincipalExtensions;

namespace TouristTourGuideWebApp.Controllers
{
    //add 4/24/2024
    [Authorize]
    public class GuideUserController : Controller
    {
        private IGuideUserService _guideUserService;
        private IImageService _imageService;
        public GuideUserController(IGuideUserService guideUserService,IImageService imageService)
        {
            _guideUserService = guideUserService;
            _imageService = imageService;
        }

        [HttpGet]
        public IActionResult BecomeGuide()
        {
            string getAppUser = ClaimPrincipalExtensions.GetCurrentUserId(this.User);
            bool isGuide = _guideUserService.isUserGuide(getAppUser);
            if (isGuide)
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
            string getUser = ClaimPrincipalExtensions.GetCurrentUserId(this.User);
            string u = getUser;
            await _guideUserService.CreateGuide(viewModel, getUser);

            return RedirectToAction("Index", "Home");
        }

        //добавил съм го на 4/26/2024
        [HttpGet]
        public async Task<IActionResult> Profile(string guideUserId)
        {

            string userId = ClaimPrincipalExtensions.GetCurrentUserId(this.User);
            string userGuideId = _guideUserService.GuidUserId(userId);
            var view = await _guideUserService.GuidUserInfo(userGuideId);
            if (_imageService.IsAppImageExist(userId))
            {
                if (await _imageService.GetAppUserImageFileUniqueNameSQL(userId)!=null)
                {
                    string fileName = await _imageService.GetAppUserImageFileUniqueNameSQL(userId);
                    byte[] filedata = _imageService.GetImageBytesMongoDb(fileName);
                    view.ImageFileData = filedata;
                }
               
            }             
            return View(view);
        }

        [HttpPost]
        public async Task<IActionResult> AddPicture(IFormFile pictureFile, string userAppId)
        {
            bool isUserExist = _guideUserService.isUserGuide(userAppId);
            if (!isUserExist)
            {
                return StatusCode(404);
            }

            string id = userAppId;
            _imageService.AddProfilePicture(pictureFile, userAppId);
            string name = await _imageService.GetImageUniqueName(userAppId);
            await _imageService.AddImageFileToMongoDb(pictureFile, name);
            string guideUserId = _guideUserService.GuidUserId(userAppId);
            
            return RedirectToAction("Profile", "GuideUser", new { guideUserId = guideUserId });
        }
    }
}
