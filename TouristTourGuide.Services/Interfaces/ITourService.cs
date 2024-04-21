using TouristTourGuide.ViewModels.TouristTourViewModels;

namespace TouristTourGuide.Services.Interfaces
{
    public interface ITourService
    {
        Task<AllToursFilteredAndPagedServiceModel> AllAsync(AllToursQueryViewModel viewModel);
        void CreateTouristTour(TouristTourCreateViewModel viewModel,string guidUserId);
        Task<bool> IsTourOwner(string guideId,string tourId);
        Task<EditViewModel> GetTourForEdit(string tourId);
        void EditTour(EditViewModel editViewModel);
        Task<DetailsViewModel> TourById(string id);
        bool isHavePictures(string tourId);
        
    }
}