﻿using TouristTourGuide.ViewModels.GuideUserViewModels;
using TouristTourGuide.ViewModels.UserGuideViewModels;

namespace TouristTourGuide.Services.Interfaces
{
    public interface IGuideUserService
    {
        Task CreateGuide(BecomeGuideUserViewModel viewModel,string applicationUserId);
        Task<GuideUserFullInfoViewModel> GuidUserInfo(string guideUserId);
        bool isUserGuide(string appUserId);
        string GuidUserId(string applicationUserId);
     
    }
}
