using Microsoft.AspNetCore.Mvc;
using TouristTourGuide.Services;
using TouristTourGuide.ViewModels.AppImageViewModels;
using TouristTourGuide.ViewModels.ApplicationImageViewModels;

namespace TouristTourGuideWebApp.Controllers
{
    public class ImageController : Controller
    {
        private readonly ImageService _imageSerive;
        public ImageController(ImageService imageService) 
        {
            _imageSerive = imageService;
        }
        [HttpGet]
        public async Task<IActionResult> EditTourAlbum(string tourId)
        {
            EditTourAlbumViewModel edit = new EditTourAlbumViewModel();
            edit.AlbumPicutres = await _imageSerive.GetAllTourImagesSqlMetaInfo(tourId);           
            return View(edit);
        }
    }
}
