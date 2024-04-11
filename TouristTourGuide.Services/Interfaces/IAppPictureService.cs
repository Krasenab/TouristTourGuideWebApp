using TouristTourGuide.ViewModels.AppImageViewModels;

namespace TouristTourGuide.Services.Interfaces
{
    public interface IAppPictureService
    {
        Task<List<AppImagesViewModel>> TourPicturesSqlData(string tourId);       
    }
}
