using TouristTourGuide.Services.Interfaces;
using TouristTourGuide.Data;
using TouristTourGuide.Data.Models.Sql.Models;
using TouristTourGuide.ViewModels.TouristTourViewModels;
using TouristTourGuide.ViewModels.LocationViewModels;
using Microsoft.EntityFrameworkCore;
using TouristTourGuide.ViewModels.EnumAppModels;
using TouristTourGuide.ViewModels.AppImageViewModels;

namespace TouristTourGuide.Services
{
    public class TourService : ITourService
    {
        private TouristTourGuideDbContext _dbContext;   
        public TourService(TouristTourGuideDbContext db)
        {
                _dbContext = db;
        }

        public async Task<AllToursFilteredAndPagedServiceModel> AllAsync(AllToursQueryViewModel viewModel)
        {
            IQueryable<TouristTour> toursQuery =  this._dbContext.TouristsTours.AsQueryable();

            if (!string.IsNullOrWhiteSpace(viewModel.Category))
            {
                toursQuery =  toursQuery.Where(x => x.Category.Name == viewModel.Category);
            }
            if (!string.IsNullOrWhiteSpace(viewModel.SerchByString))
            {
                string wildCard = $"%{viewModel.SerchByString.ToLower()}%";

                toursQuery = toursQuery.Where(t => EF.Functions.Like(t.TourName, wildCard) ||
                                                   EF.Functions.Like(t.Duaration, wildCard) ||
                                                   EF.Functions.Like(t.Location.Country, wildCard) ||
                                                   EF.Functions.Like(t.Location.City,wildCard)||
                                                   EF.Functions.Like(t.Location.Village, wildCard));
            }

            toursQuery = viewModel.TourSorting switch
            {
                TourSorting.Newest => toursQuery.OrderBy(c => c.CreatedOn),
                TourSorting.Oldest => toursQuery.OrderByDescending(c => c.CreatedOn),
                TourSorting.PriceAscending => toursQuery.OrderBy(x => x.PricePerPerson),
                TourSorting.PriceDescending => toursQuery.OrderByDescending(x => x.PricePerPerson),


            };

            

            List<AllViewModel> allTour = await toursQuery.Skip((viewModel.CurrentPage - 1) * viewModel.TourPerPage)
              .Take(viewModel.TourPerPage)
              .Select( t => new AllViewModel()
              {
                  Id = t.Id.ToString(),
                  Title = t.TourName,
                  TourImage = t.TourImages.Where(i => i.TouristTourId == t.Id).Select(x => new AppImagesViewModel()
                  {
                      UniqueFileName = x.UniqueFileName,
                      TouristTourId = x.TouristTourId.ToString()                      
                  }).FirstOrDefault(),
                  Location = t.Location.Country ?? "Unknown Coutry",
                  LocationCity = t.Location.City.ToString() ?? "Unknown City",                  
                  PricePerPerson = t.PricePerPerson
              }).ToListAsync();

            int totalsTour = allTour.Count();

            return new AllToursFilteredAndPagedServiceModel()
            {
                TotalTourCount = totalsTour,
                Tours = allTour
            };

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

        public Task Delete(string tourId, string ownerId)
        {
            throw new NotImplementedException();
        }

        public void EditTour(EditViewModel editViewModel)
        {
            TouristTour ?tour = _dbContext.TouristsTours.Where(x => x.Id.ToString() == editViewModel.TourId)
                .FirstOrDefault();
            tour.TourName = editViewModel.TourName;
            tour.Duaration = editViewModel.Duaration;
            tour.MeetingPoint = editViewModel.MeetingPoint;
            tour.MeetingPointMapUrl = editViewModel.MeetingPointMapUrl;
            tour.FullDescription = editViewModel.FullDescription;
            tour.PricePerPerson = editViewModel.PricePerPerson;
            tour.LocationId = editViewModel.LocationId;
            tour.CategoryId = editViewModel.CategoryId;
            tour.WhatToBring = editViewModel.WhatToBring;
            tour.KnowBeforeYouGo = editViewModel.KnowBeforeYouGo;
            

            _dbContext.SaveChanges();
        }

        public async Task<EditViewModel> GetTourForEdit(string tourId)
        {

            TouristTour? getTour = await _dbContext.TouristsTours
                .Where(x => x.Id.ToString() == tourId)
                .FirstOrDefaultAsync();

           

            EditViewModel viewModel = new EditViewModel()
            {
                TourId = getTour.Id.ToString(),
                TourName = getTour.TourName,
                Duaration = getTour.Duaration,
                PricePerPerson = getTour.PricePerPerson,
                NotSuitableFor = getTour.NotSuitableFor,
                MeetingPoint = getTour.MeetingPoint,
                WhatToBring = getTour.WhatToBring,
                FullDescription = getTour.FullDescription,
                KnowBeforeYouGo = getTour.KnowBeforeYouGo,
                LocationId = getTour.LocationId,
                CategoryId = getTour.CategoryId
                                
            };


            int brak = 0;
            return viewModel;
        }

        public bool isHavePictures(string tourId)
        {
            bool isHavePictures = _dbContext.TouristsTours
                .Where(x=> x.TourImages.Any(y=>y.TouristTourId.ToString()==tourId)).Any();

            return isHavePictures;
        }

        public bool IsTourExist(string tourId)
        {
           bool isExist = _dbContext.TouristsTours.Where(x=>x.Id.ToString()==tourId)
                .Any();
            return isExist;
        }

        public async Task<bool> IsTourOwner(string guideId, string tourId)
        {
            return await _dbContext.TouristsTours.AnyAsync(x => x.GuideUserId.ToString() == guideId
             && x.Id.ToString() == tourId);
        }

        public async Task<DetailsViewModel> TourById(string tourId)
        {
            
            var getTour = await _dbContext.TouristsTours
                .Where(id=>id.Id.ToString()==tourId)
                .Select( t=> new DetailsViewModel() 
                {
                    Id = t.Id.ToString(),
                    TourName= t.TourName,
                    Duaration = t.Duaration,
                    PricePerPerson = t.PricePerPerson,
                    Highlights = t.Highlights,
                    FullDescription = t.FullDescription,
                    NotSuitableFor = t.NotSuitableFor,
                    MeetingPoint = t.MeetingPoint,
                    MeetingPointMapUrl = t.MeetingPointMapUrl,
                    Includes = t.Includes,
                    WhatToBring = t.WhatToBring,
                    KnowBeforeYouGo = t.KnowBeforeYouGo,
                    CreatedOn = t.CreatedOn.ToString(),
                    LocationCountry = t.Location.Country,
                    LocationCity = t.Location.City,
                    Category = t.Category.Name
                })
                .FirstOrDefaultAsync();
            return getTour;            
        }
    }
}
