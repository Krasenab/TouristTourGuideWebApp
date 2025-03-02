using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristTourGuide.Data;
using TouristTourGuide.Data.Models.Sql.Models;
using TouristTourGuide.Services.Interfaces;
using TouristTourGuide.ViewModels.AppUserTourViewModels;

namespace TouristTourGuide.Services
{
    public class AppUserTourService : IAppUserTourService
    {
        private readonly TouristTourGuideDbContext _db;
        public AppUserTourService(TouristTourGuideDbContext db)
        {
                _db = db;
        }

        public void AddToWishList(string tourId, string appUserId)
        {
            
           
            AppUsersTours ap = new AppUsersTours()
            {
                ApplicationUserId = Guid.Parse(appUserId),
                TouristTourId = Guid.Parse(tourId)
            };

            _db.AppUsersTours.Add(ap);
            _db.SaveChanges();
        }

        public async Task<List<UserTourWishLIstViewModel>> GetAllAppUserWishToursAsync(string appUserId)
        {
            List<UserTourWishLIstViewModel> wishList = await _db.AppUsersTours.Where(a=>a.ApplicationUserId.ToString() == appUserId)
                .Select(b=> new UserTourWishLIstViewModel 
                {
                    TourName = b.TouristTour.TourName,
                    TourId  =b.TouristTourId.ToString(),
                    AppUserId = b.ApplicationUserId.ToString(),
                    Description = b.TouristTour.FullDescription,
                    Location = "Country:" + b.TouristTour.Location.Country + " " + "City:" + b.TouristTour.Location.City,
                    
                    

                }).ToListAsync();

            


            if (wishList.Count==0)
            {
                return new List<UserTourWishLIstViewModel>();
            }
            return wishList;
        }

        public async Task<bool> IsAddedInList(string appUserId, string tourId)
        {
            bool isExist = await _db.AppUsersTours.Where(x=>x.TouristTourId.ToString() == tourId && x.ApplicationUserId.ToString()==appUserId).AnyAsync();
            if(!isExist) 
            {
                return isExist;
            }

            return isExist;
        }

        public async Task RemoveFromWish(string tourId, string appUserId)
        {
            AppUsersTours? apT = await _db.AppUsersTours.Where(a => a.ApplicationUserId.ToString() == appUserId && a.TouristTourId.ToString() == tourId).FirstOrDefaultAsync();
            _db.AppUsersTours.Remove(apT);
            await _db.SaveChangesAsync();
        }


    }
}
