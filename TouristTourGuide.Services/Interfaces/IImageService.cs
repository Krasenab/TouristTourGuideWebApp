using Microsoft.AspNetCore.Http;
using System.Net;
using TouristTourGuide.ViewModels.AppImageViewModels;

namespace TouristTourGuide.Services.Interfaces
{
    public interface IImageService
    {      
        void AddTourImage(string tourId,IFormFile imageFile,string userId);
        void AddTourImageFileMongoDb(IFormFile imageFile,string userId, string tourId);
        bool IsFileExtensionValid(IFormFile imageFile);

       Task<List<AppImagesViewModel>> GetTourImgMongoDb(string tourId);
  
    }
}
