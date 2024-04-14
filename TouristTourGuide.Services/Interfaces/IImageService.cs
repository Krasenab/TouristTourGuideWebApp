﻿using Microsoft.AspNetCore.Http;
using System.Net;
using TouristTourGuide.ViewModels.AppImageViewModels;
using TouristTourGuide.ViewModels.ApplicationImageViewModels;

namespace TouristTourGuide.Services.Interfaces
{
    public interface IImageService
    {
        Task AddTourImage(string tourId, IFormFile imageFile, string userId);
        Task AddTourImageFileMongoDb(IFormFile imageFile, string userId, string tourId);
        bool IsFileExtensionValid(IFormFile imageFile);
        Task<List<AppImagesViewModel>> GetTourImgMongoDb(string tourId);

        Task<List<AppImagesViewModel>> GetTop3TourImagesFileMongoDb(string tourId);
    }
}
