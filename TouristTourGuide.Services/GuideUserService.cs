using TouristTourGuide.Data;
using TouristTourGuide.Services.Interfaces;
using TouristTourGuide.ViewModels.UserGuideViewModels;

namespace TouristTourGuide.Services
{
    public class GuideUserService : IGuideUserService
    {
        private readonly TouristTourGuideDbContext _dbContext;
        public GuideUserService(TouristTourGuideDbContext dbContext)
        {
                _dbContext = dbContext; 
        }
        public Task<GuideUserFullInfoViewModel> GuidUserInfo()
        {
            throw new NotImplementedException();
        }

        public string GuidUserId(string applicationUserId)
        {                     
            var getGuide = _dbContext.GuideUsers.Where(x =>x.ApplicationUserId.ToString()==applicationUserId).FirstOrDefault();

            var guideId = getGuide.Id;
            return guideId.ToString();
        }
      
    }
}
