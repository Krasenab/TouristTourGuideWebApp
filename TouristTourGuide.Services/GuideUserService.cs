using TouristTourGuide.Data;
using TouristTourGuide.Services.Interfaces;
using TouristTourGuide.ViewModels.UserGuideViewModels;
using static TouristTourGuide.Infrastrucutre.ClaimPrincipalExtensions;
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

       public string GuidUserId(string applicationUserId) => GuidUserId(applicationUserId);
      
    }
}
