using TouristTourGuide.ViewModels.TouristTourViewModels;

namespace TouristTourGuide.Services.Interfaces
{
    public interface ITourService
    {
        void CreateTouristTour(TouristTourCreateViewModel viewModel,string guidUserId);
        Task<EditViewModel> GetTourForEdit(string tourId);
        void EditTour(EditViewModel editViewModel);
        Task<DetailsViewModel> TourById(string id);

    }
}