using Microsoft.AspNetCore.Http;
using System.Net;
using TouristTourGuide.ViewModels.AppImageViewModels;
using TouristTourGuide.ViewModels.ApplicationImageViewModels;

namespace TouristTourGuide.Services.Interfaces
{
    public interface IImageService
    {
        byte[] GetImageBytesMongoDb (string uqnicName);
        Task AddTourImage(string tourId, IFormFile imageFile, string userId);
        Task AddImageFileToMongoDb(IFormFile imageFile,string uniqueFileName);
        bool IsFileExtensionValid(IFormFile imageFile);
        List<AppImagesViewModel> GetImagesFilesMongoDb(string uniqueFileName);
        Task<string> TourImageUniqueName(string tourId);

    }
}
