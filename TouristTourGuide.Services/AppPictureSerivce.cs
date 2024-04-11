

using TouristTourGuide.Services.Interfaces;
using TouristTourGuide.ViewModels.AppImageViewModels;

namespace TouristTourGuide.Services
{
    public class AppPictureSerivce : IAppPictureService
    {
        public Task<List<AppImagesViewModel>> TourPicturesSqlData(string tourId)
        {
            throw new NotImplementedException();
        }
    }
}
