using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristTourGuide.ViewModels.AppUserTourViewModels;

namespace TouristTourGuide.Services.Interfaces
{
    public interface IAppUserTourService
    {
        Task<List<UserTourWishLIstViewModel>> GetAllAppUserWishToursAsync(string appUserId);
        void AddToWishList(string tourId, string appUserId);
        Task<bool> IsAddedInList(string appUserId, string tourId);
        Task RemoveFromWish(string tourId,string appUserId);

    }
}
