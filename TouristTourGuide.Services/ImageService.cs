using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TouristTourGuide.Data;
using TouristTourGuide.Data.Models.MongoDb.Models;
using TouristTourGuide.Data.Models.Sql.Models;
using TouristTourGuide.Services.Interfaces;
using TouristTourGuide.ViewModels.AppImageViewModels;
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

        public async void AddTourImageFileMongoDb(IFormFile imageFile, string userId, string tourId)
        {
            string fileName = _dbContext.AppImages.Where(x => x.TouristTourId == Guid.Parse(tourId))
                .Select(x => x.FileName)
                .FirstOrDefault();

            using (MemoryStream memoryStreem = new MemoryStream())
            {
                await imageFile.CopyToAsync(memoryStreem);

                AppImageFile imgFile = new AppImageFile()
                {
                    FileData = memoryStreem.ToArray(),
                    FileName = fileName,
                    TouristTourId = tourId,
                    ApplicationUserId = userId
                };

                _appImageFileCollectionMDB.InsertOne(imgFile);
            };
        }

        public void AddTourImage(string tourId, IFormFile imageFile, string userId)
        {
            AppImages img = new AppImages()
            {
                FileName = GenerateUnicFileName(imageFile.FileName),
                TouristTourId = Guid.Parse(tourId),
                ApplicationUserId = Guid.Parse(userId),
            };
            _dbContext.AppImages.Add(img);
            _dbContext.SaveChanges();
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

        public async Task<List<AppImagesViewModel>> GetTourImgMongoDb(string tourId)
        {
            List<AppImagesViewModel> fileImges = await
                _appImageFileCollectionMDB
                .Find(tId => tId.TouristTourId.ToString() == tourId)
                .Project(x => new AppImagesViewModel
                {
                    FileData = x.FileData,
                    FileName = x.FileName,
                    ApplicationUserId = x.ApplicationUserId,
                    TouristTourId = x.TouristTourId
                })
                .ToListAsync();
                

            if (fileImges.Count==0)
            {
               
            }

            return fileImges;

        }
    }
}
