﻿
using TouristTourGuide.ViewModels;

namespace TouristTourGuide.Services.Interfaces
{
    public interface ITourService
    {
        void CreateTouristTour(TouristTourCreateViewModel viewModel,string guidUserId);
    }
}
