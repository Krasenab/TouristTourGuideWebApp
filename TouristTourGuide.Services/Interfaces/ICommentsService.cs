using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristTourGuide.ViewModels.CommentsViewModels;

namespace TouristTourGuide.Services.Interfaces
{
    public interface ICommentsService
    {
    
        Task<CommentResponseViewModel> GetLatestCommentsAsync(string userId);
        Task Create(string tourId,string content,string appUserId);
        Task<List<AllComentsViewModels>> GetAllComentAsync(string tourId);

        //добавил съм го на 4/27/2024
        void DeleteTourComments(string tourId);

    }
}
