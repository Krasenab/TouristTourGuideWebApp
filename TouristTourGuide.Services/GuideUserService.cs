using System;
using TouristTourGuide.Data;
using TouristTourGuide.Data.Models.Sql.Models;
using TouristTourGuide.Services.Interfaces;
using TouristTourGuide.ViewModels.GuideUserViewModels;
using TouristTourGuide.ViewModels.UserGuideViewModels;

namespace TouristTourGuide.Services
{
    public class GuideUserService : IGuideUserService
    {
        private readonly TouristTourGuideDbContext _dbContext;
        public GuideUserService(TouristTourGuideDbContext dbContext)
        {
                _dbContext = dbContext; 
        }
        public Task<GuideUserFullInfoViewModel> GuidUserInfo()
        {
            throw new NotImplementedException();
        }

        public string GuidUserId(string applicationUserId)
        {                     
            var getGuide = _dbContext.GuideUsers.Where(x =>x.ApplicationUserId.ToString()==applicationUserId).FirstOrDefault();

            var guideId = getGuide.Id;
            return guideId.ToString();
        }

        public bool isUserGuide(string appUserId)
        {
           return _dbContext.GuideUsers.Any(au=>au.ApplicationUserId.ToString()==appUserId);
        }

        public async Task CreateGuide(BecomeGuideUserViewModel viewModel,string applicationUserId)
        {
            
                GuideUser guideUser = new GuideUser()
                {
                    Name = viewModel.Name,
                    LegalFirmName = viewModel.LegalFirmName,
                    AboutTheActivityProvider = viewModel.AboutTheActivityProvider,
                    RegisteredAddress = viewModel.RegisteredAddress,
                    ApplicationUserId = Guid.Parse(applicationUserId),
                    CompanyRegistrationNumber = viewModel.CompanyRegistrationNumber,
                    PhoneNumber = viewModel.PhoneNumber,
                    ValueAddedTaxIdentificationNumber = viewModel.ValueAddedTaxIdentificationNumber,
                    Email = viewModel.Email
                    
                };

            await _dbContext.GuideUsers.AddAsync(guideUser);
            await _dbContext.SaveChangesAsync();
            
        }
    }
}
