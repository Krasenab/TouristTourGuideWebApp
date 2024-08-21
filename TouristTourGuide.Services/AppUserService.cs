using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristTourGuide.Data;
using TouristTourGuide.Services.Interfaces;
using TouristTourGuide.ViewModels.AppUserViewModels;

namespace TouristTourGuide.Services
{
    public class AppUserService : IAppUserService
    {
        private readonly TouristTourGuideDbContext _touristTourGuideDbContext;
        public AppUserService(TouristTourGuideDbContext touristTourGuideDbContext)
        {
            this._touristTourGuideDbContext = touristTourGuideDbContext;     
        }

        public async Task<List<ProfileViewModel>> GetAllUserAsync()
        {
            var getAll = await _touristTourGuideDbContext.ApplicationUsers
                .Select(p => new ProfileViewModel() 
                {
                    AppUserId = p.Id.ToString(),
                    Email = p.Email,
                    Name = p.FirstName + " " + p.LastName,
                    FaceBookUrl = p.FaceBookUrl                    
                }).ToListAsync();

            foreach (var user in getAll) 
            {
                user.PhoneNumber =  _touristTourGuideDbContext.GuideUsers
                    .Where(x => x.ApplicationUserId.ToString() == user.AppUserId)
                    .Select(p=>p.PhoneNumber)
                    .FirstOrDefault();
            }
            return getAll;
                
        }

        public async Task<ProfileViewModel> GetAppUserPrfileInfo(string userId)
        {
            ProfileViewModel p = await _touristTourGuideDbContext.Users.Where(x=>x.Id.ToString()==userId)
                .Select(x=> new ProfileViewModel() 
                {
                    AppUserId = x.Id.ToString(),
                    Email = x.Email,
                    Name = x.FirstName + x.LastName
                }).FirstOrDefaultAsync();

            return p;
        }

        public Task<string> GetFullNameById(string userId)
        {
            throw new NotImplementedException();
        }

    }
}
