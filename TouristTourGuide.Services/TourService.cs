using TouristTourGuide.Services.Interfaces;
using TouristTourGuide.ViewModels;
using TouristTourGuide.Data;
using TouristTourGuide.Data.Models.Sql.Models;
using TouristTourGuide.ViewModels.TouristTourViewModels;
using Microsoft.EntityFrameworkCore;

namespace TouristTourGuide.Services
{
    public class TourService : ITourService
    {
        private TouristTourGuideDbContext _dbContext;   
        public TourService(TouristTourGuideDbContext db)
        {
                _dbContext = db;
        }
        public async void CreateTouristTour(TouristTourCreateViewModel viewModel, string guidUserId)
        {
            string userIdG = guidUserId;

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
                CategoryId = viewModel.CategoryId,
                GuideUserId = Guid.Parse(guidUserId)
            };

            await _dbContext.TouristsTours.AddAsync(tour);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<EditViewModel> GetTourForEdit(string tourId)
        {
            EditViewModel getTour = await _dbContext.TouristsTours
                .Where(x => x.Id.ToString() == tourId)
                .Select(x=> new EditViewModel() 
                {
                    TourName= x.TourName,
                    Duaration= x.Duaration,
                    PricePerPerson= x.PricePerPerson,
                    NotSuitableFor =x.NotSuitableFor,
                    MeetingPoint = x.MeetingPoint,
                    WhatToBring  = x.WhatToBring,
                    FullDescription = x.FullDescription,
                    LocationCity = x.Location.City,
                    CategoryId = x.CategoryId,
                    LocationId = x.Location.Id,



                })
                .FirstOrDefaultAsync();

            throw new NotImplementedException();
        }
    }
}
