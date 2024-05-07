using Microsoft.AspNetCore.Mvc;
using TouristTourGuide.Services;
using TouristTourGuide.Services.Interfaces;
using TouristTourGuide.ViewModels.AppImageViewModels;
using TouristTourGuide.ViewModels.ApplicationImageViewModels;
using TouristTourGuide.ViewModels.ApplicationImageViewModels.EditTourAlbumViewModel;

namespace TouristTourGuideWebApp.Controllers
{
    public class AppImageController : Controller
    {
        private  IImageService _imageSerive;
        public AppImageController(IImageService imageService) 
        {
            _imageSerive = imageService;
        }
        [HttpGet]
        public async Task<IActionResult> EditTourAlbum(string tourId)
        {          
            EditTourAlbumViewModel viewModel = new EditTourAlbumViewModel();
            viewModel.TourId = tourId;
            List<string> names = await _imageSerive.GetAllTourUniqNameImages(tourId);
            var isNull = _imageSerive.GetAllImagesFileByListOfUniqueName(names);
            viewModel.TourImages = isNull;
            return View(viewModel);
        }
    }
}
