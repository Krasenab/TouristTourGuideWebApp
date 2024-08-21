using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristTourGuide.ViewModels.AppUserViewModels;

namespace TouristTourGuide.Services.Interfaces
{
    public interface IAppUserService
    {
        Task<string> GetFullNameById(string userId);
        Task<ProfileViewModel> GetAppUserPrfileInfo(string userId);
        Task<List<ProfileViewModel>> GetAllUserAsync();
    }
}
