using Microsoft.EntityFrameworkCore;
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
        public async Task<GuideUserFullInfoViewModel> GuidUserInfo(string guideUserId)
        {
            //добавил съм го на 4/25/2024г
            var guideUser = await _dbContext.GuideUsers.Where(x => x.Id.ToString() == guideUserId)
                 .Select(x => new GuideUserFullInfoViewModel()
                 {
                     Id = x.Id.ToString(),
                     Name = x.Name,
                     AboutTheActivityProvider = x.AboutTheActivityProvider,
                     ValueAddedTaxIdentificationNumber = x.ValueAddedTaxIdentificationNumber,
                     RegisteredAddress = x.RegisteredAddress,
                     Email=x.Email,
                     CompanyRegistrationNumber = x.CompanyRegistrationNumber,
                     PhoneNumber = x.PhoneNumber
                 }).FirstOrDefaultAsync();

            if (guideUser==null)
            {
                throw new NullReferenceException("Something get wrong");
            }
            return guideUser;
            
        }

        public string GuidUserId(string applicationUserId)
        {
            var getGuide = _dbContext.GuideUsers.Where(x => x.ApplicationUserId.ToString() == applicationUserId).FirstOrDefault();

            var guideId = getGuide.Id;
            return guideId.ToString();
        }

        public bool isUserGuide(string appUserId)
        {
            return _dbContext.GuideUsers.Any(au => au.ApplicationUserId.ToString() == appUserId);
        }

        public async Task CreateGuide(BecomeGuideUserViewModel viewModel, string applicationUserId)
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
