using Microsoft.AspNetCore.Http;
using System.Net;
using System.Security;
using TouristTourGuide.Data.Models.Sql.Models;
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
        //add on 4/27/2024
        Task<List<string>> GetAllTourUniqNameImages(string tourId);
        void DeleteManyTourImageFileMongoDb(List<string> fileUniqNames);
        void DeleteTourImagesSql(string tourId);
        void AddProfilePicture(IFormFile profilePicture, string applicationUserId);
        Task<string> GetImageUniqueName(string uniqueName);
        //add afet 24
        bool IsAppImageExist(string applicationUserId);
        Task<string> GetAppUserImageFileUniqueNameSQL(string appUserId);
        Task DelateImageByUniqName(string name);
        Task<List<AppImagesViewModel>> GetAllTourImagesSqlMetaInfo(string tourId);
        Task<AppImageSqlMetaDataViewModel> AppImageInfo(string uniqueName);

    }
}
