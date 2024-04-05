using TouristTourGuide.Services.Interfaces;
using TouristTourGuide.ViewModels;
using TouristTourGuide.Data;
using TouristTourGuide.Data.Models.Sql.Models;
using static TouristTourGuide.Infrastrucutre.ClaimPrincipalExtensions;
namespace TouristTourGuide.Services
{
    public class TourService : ITourService
    {
        private TouristTourGuideDbContext _dbContext;   
        public TourService(TouristTourGuideDbContext db)
        {
                _dbContext = db;
        }
        public async void CreateTouristTour(TouristTourCreateViewModel viewModel, Guid userGuideId)
        {
             
            TouristTour tour = new TouristTour()
            {
                TourName = viewModel.TourName,
                Duaration = viewModel.Duaration,
                PricePerPerson = viewModel.PricePerPerson,
                FullDescription = viewModel.FullDescription,
                NotSuitableFor = viewModel.NotSuitableFor,
                MeetingPoint = viewModel.MeetingPoint,
                MeetingPointMapUrl = viewModel.MeetingPoint,
                WhatToBring = viewModel.WhatToBring,
                KnowBeforeYouGo = viewModel.KnowBeforeYouGo,
                LocationId = viewModel.LocationId,
                CategoryId = viewModel.CategoryId
            };

            await _dbContext.TouristsTours.AddAsync(tour);
            await _dbContext.SaveChangesAsync();
        }
    }
}
