using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
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

        public async Task AddTourImageFileMongoDb(IFormFile imageFile, string userId, string tourId)
        {
            string fileName = await  _dbContext.AppImages.Where(x => x.TouristTourId == Guid.Parse(tourId))
                .Select(x => x.FileName)
                .FirstOrDefaultAsync(); 

           await using (MemoryStream memoryStreem = new MemoryStream())
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

        public async Task AddTourImage(string tourId, IFormFile imageFile, string userId)
        {
            string generateFileNewFileName = GenerateUnicFileName(imageFile.FileName);

            AppImages img = new AppImages()
            {
                FileName = generateFileNewFileName,
                TouristTourId = Guid.Parse(tourId),
                ApplicationUserId = Guid.Parse(userId),
            };
           await _dbContext.AppImages.AddAsync(img);
            await _dbContext.SaveChangesAsync();
 
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

            return fileImges;

        }

        public async Task<List<AppImagesViewModel>> GetTop3TourImagesFileMongoDb(string tourId)
        {
            int isTourHaveThreeAppPic = _dbContext.AppImages
               .Where(x => x.TouristTourId.ToString() == tourId)
               .Count();

       
            var getTourImagesSql = await  _dbContext.AppImages
                .Where(t => t.TouristTourId.ToString() == tourId)
                .Select(x => new AppImageSqlMetaDataViewModel()
                {
                    FileName = x.FileName,
                    ApplicationUserId = x.ApplicationUserId.ToString(),
                    TouristTourId = x.TouristTourId.ToString()
                })
                .ToListAsync();


            return null;
          
        }
    }
}
