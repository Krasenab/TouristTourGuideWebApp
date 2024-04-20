using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristTourGuide.ViewModels.GuideUserViewModels;
using TouristTourGuide.ViewModels.UserGuideViewModels;

namespace TouristTourGuide.Services.Interfaces
{
   public interface IGuideUserService
    {
        Task CreateGuide(BecomeGuideUserViewModel viewModel,string applicationUserId);
        Task<GuideUserFullInfoViewModel> GuidUserInfo();
        bool isUserGuide(string appUserId);
        string GuidUserId(string applicationUserId);
    }
}
