using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristTourGuide.ViewModels.UserGuideViewModels;

namespace TouristTourGuide.Services.Interfaces
{
    interface IGuideUserService
    {
        Task<GuideUserFullInfoViewModel> GuidUserInfo();
        string GuidUserId(string applicationUserId);
    }
}
