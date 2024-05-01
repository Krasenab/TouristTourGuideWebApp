using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Reflection;
using TouristTourGuide.Data;
using TouristTourGuide.Data.Models.MongoDb.Models;
using TouristTourGuide.Data.Models.Sql.Models;
using TouristTourGuide.Services.Interfaces;
using TouristTourGuide.ViewModels.AppImageViewModels;
using TouristTourGuide.ViewModels.ApplicationImageViewModels;
using static TouristTourGuide.Infrastrucutre.AppFileExtension;

namespace TouristTourGuide.Services
{

    public class ImageService : IImageService
    {
        private readonly IMongoCollection<AppImageFile> _appImageFileCollectionMDB;
        private readonly TouristTourGuideDbContext _dbContext;
        private readonly IMongoClient mongoClient = new MongoClient();



        public ImageService(TouristTourGuideDbContext dbContext)
        {
            _dbContext = dbContext;
            _appImageFileCollectionMDB = mongoClient.GetDatabase("TouristTourGuideWebAppMDB").GetCollection<AppImageFile>("TouristTourGuideWebAppImages");

        }


        public async Task AddImageFileToMongoDb(IFormFile imageFile, string uniqueFileName)
        {
            await using (MemoryStream memoryStream = new MemoryStream())
            {
                await imageFile.CopyToAsync(memoryStream);

                AppImageFile file = new AppImageFile()
                {
                    FileData = memoryStream.ToArray(),
                    UniqueFileName = uniqueFileName
                };

                _appImageFileCollectionMDB.InsertOne(file);

            }
        }
        public async Task AddTourImage(string tourId, IFormFile imageFile, string userId)
        {
            string generateFileNewFileName = GenerateUnicFileName(imageFile.FileName);

            AppImages img = new AppImages()
            {
                UniqueFileName = generateFileNewFileName,
                TouristTourId = Guid.Parse(tourId),
                ApplicationUserId = Guid.Parse(userId),
            };
            await _dbContext.AppImages.AddAsync(img);
            await _dbContext.SaveChangesAsync();

        }

        public void DeleteTourImagesSql(string tourId)
        {
            var getAppImageMetaData = _dbContext.AppImages.Where(x => x.TouristTourId.ToString() == tourId)
                  .ToList();

            _dbContext.RemoveRange(getAppImageMetaData);
            _dbContext.SaveChanges();
        }

        public void DeleteManyTourImageFileMongoDb(List<string> fileUniqNames)
        {
            foreach (string fileName in fileUniqNames)
            {
                var filterFile = Builders<AppImageFile>.Filter.Eq("UniqueFileName", fileName);
                _appImageFileCollectionMDB.DeleteOneAsync(filterFile);

            }
        }

        public async Task<List<string>> GetAllTourUniqNameImages(string tourId)
        {
            List<string> names = await _dbContext.AppImages.Where(x => x.TouristTourId.ToString() == tourId)
                .Select(x => x.UniqueFileName).ToListAsync();

            return names;
        }

        public byte[] GetImageBytesMongoDb(string uqnicName)
        {

            var fileObject = _appImageFileCollectionMDB.Find(x => x.UniqueFileName == uqnicName)
                .Project(x => new AppImagesViewModel()
                {
                    FileData = x.FileData
                }).FirstOrDefault();

            return fileObject.FileData;
        }

        public List<AppImagesViewModel> GetImagesFilesMongoDb(string uniqueFileName)
        {
            List<AppImagesViewModel> appImageFiles = _appImageFileCollectionMDB
                 .Find(x => x.UniqueFileName == uniqueFileName)
                 .Project(aif => new AppImagesViewModel
                 {
                     UniqueFileName = aif.UniqueFileName,
                     FileData = aif.FileData
                 }).ToList();

            return appImageFiles;
        }
        public bool IsFileExtensionValid(IFormFile imageFile)
        {
            string fileExtns = Path.GetExtension(imageFile.FileName);
            if (!allowedExtensions.Any(n => fileExtns.EndsWith(n)))
            {
                return false;
            }
            return true;
        }



        public async Task<string> TourImageUniqueName(string tourId)
        {
            string fileName = await _dbContext.AppImages.Where(x => x.TouristTourId == Guid.Parse(tourId))
                .Select(x => x.UniqueFileName)
                .FirstOrDefaultAsync();

            if (String.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException("The uniqueFile is null or not exist");
            }

            return fileName;
        }

        public void AddProfilePicture(IFormFile profilePicture, string applicationUserId)
        {
            string uniqueName = GenerateUnicFileName(profilePicture.FileName);
            AppImages newProfilePicture = new AppImages()
            {
                ApplicationUserId = Guid.Parse(applicationUserId),
                UniqueFileName = uniqueName
            };
            _dbContext.AppImages.Add(newProfilePicture);
            _dbContext.SaveChanges();

        }

        public async Task<string> GetImageUniqueName(string uniqueName)
        {
            return await _dbContext.AppImages.Where(x => x.ApplicationUserId.ToString() == uniqueName && x.TouristTourId == null)
          .Select(x => x.UniqueFileName)
          .FirstOrDefaultAsync();
        }

        public bool IsAppImageExist(string applicationUserId)
        {
            return _dbContext.AppImages.Any(x => x.ApplicationUserId.ToString() == applicationUserId);
        }

        public async Task<string> GetAppUserImageFileUniqueNameSQL(string appUserId)
        {
            string name = await _dbContext.AppImages.Where(x => x.ApplicationUserId.ToString() == appUserId && x.TouristTourId==null)
              .Select(n => n.UniqueFileName)
              .FirstOrDefaultAsync();

            return name;
        }

        public async Task DelateImageByUniqName(string name)
        {
           var picture = await _dbContext.AppImages.Where(x=>x.UniqueFileName==name)
                .FirstOrDefaultAsync();
            _dbContext.AppImages.Remove(picture);
            await _dbContext.SaveChangesAsync();
           
        }

        public async Task<AppImageSqlMetaDataViewModel> AppImageInfo(string uniqueName)
        {
            AppImageSqlMetaDataViewModel ?appImages = await _dbContext.AppImages.Where(x => x.UniqueFileName == uniqueName)
                 .Select(x => new AppImageSqlMetaDataViewModel()
                 {
                     ApplicationUserId = x.ApplicationUserId.ToString(),
                     FileName = x.UniqueFileName,
                     TouristTourId = x.TouristTourId.ToString()

                 }).FirstOrDefaultAsync();
            if (appImages==null)
            {
                throw new ArgumentNullException("name is not null");
            }

            return appImages;   
        }

        public Task<List<AppImagesViewModel>> GetAllTourImagesSqlMetaInfo(string tourId)
        {
           return _dbContext.AppImages.Where(x=>x.TouristTourId.ToString()==tourId)
                .Select(d=>new AppImagesViewModel() 
                {
                    Id = d.Id,
                    ApplicationUserId = d.ApplicationUserId.ToString(),
                    TouristTourId = d.TouristTourId.ToString(),
                    UniqueFileName = d.UniqueFileName,
                    FileName = d.UniqueFileName,
                    
                }).ToListAsync();
        }
    }
}
