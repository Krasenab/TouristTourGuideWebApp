using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristTourGuide.ViewModels.UserGuideViewModels;

namespace TouristTourGuide.Services.Interfaces
{
   public interface IGuideUserService
    {        
        Task<GuideUserFullInfoViewModel> GuidUserInfo();
        bool isUserGuide(string appUserId);
        string GuidUserId(string applicationUserId);
    }
}
