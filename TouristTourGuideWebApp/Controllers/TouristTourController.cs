﻿using Microsoft.AspNetCore.Mvc;
using TouristTourGuide.Infrastrucutre;
using TouristTourGuide.Services;
using TouristTourGuide.ViewModels;
using static TouristTourGuide.Infrastrucutre.ClaimPrincipalExtensions;

namespace TouristTourGuideWebApp.Controllers
{
    public class TouristTourController : Controller
    {
        private TourService _tourService;
        private LocationService _locationService;
        private CategoryService _categoryService;
        private GuideUserService _guideUserService;
        public TouristTourController(TourService tourService,LocationService locationService
            ,CategoryService categoryService,GuideUserService guideUserService)
        {
                this._tourService = tourService;
                this._locationService = locationService;
                this._categoryService = categoryService;
                this._guideUserService = guideUserService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            string userId = this.User.GetCurrentUserId();
           
            TouristTourCreateViewModel model = new TouristTourCreateViewModel()
            {
                Locations = _locationService.GetAllLocations(),
                Categories = _categoryService.GetAllCategories(),
                GuideUserId = _guideUserService.GuidUserId(userId)     
            };
            return View(model);
        }

        [HttpGet]
        public  IActionResult Create(TouristTourCreateViewModel model) 
        {
            //string getGuidUserId = _guideUserService.GuidUserId(ClaimPrincipalExtensions.GetCurrentUserId(this.User));
            _tourService.CreateTouristTour(model);
            return RedirectToAction ("Index", "Home");
        }

    }
}
