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
            var toGuid = Guid.Parse(applicationUserId);
            string getId = _dbContext.GuideUsers.Where(x =>x.Id==toGuid).FirstOrDefault().ToString();
            return getId;
        }
      
    }
}
