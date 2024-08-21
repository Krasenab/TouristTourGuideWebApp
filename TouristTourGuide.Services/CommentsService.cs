using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristTourGuide.Data;
using TouristTourGuide.Data.Models.Sql.Models;
using TouristTourGuide.Services.Interfaces;
using TouristTourGuide.ViewModels.CommentsViewModels;

namespace TouristTourGuide.Services
{
    public class CommentsService : ICommentsService
    {
        private TouristTourGuideDbContext _db;
        public CommentsService(TouristTourGuideDbContext dbContext)
        {
            _db = dbContext;
        }
        public async Task Create(string tourId, string content, string appUserId)
        {
            Comments c = new Comments()
            {
                TouristTourId = Guid.Parse(tourId),
                Content = content,
                ApplicationUserId = Guid.Parse(appUserId)
            };
            await _db.Comments.AddAsync(c);
            await _db.SaveChangesAsync();

        }
        //add 4/27/2024
        public void DeleteTourComments(string tourId)
        {
            var getComments = _db.Comments.Where(x => x.TouristTourId.ToString() == tourId)
                 .ToList();

            _db.RemoveRange(getComments);
            _db.SaveChanges();
        }

        public async Task<List<AllComentsViewModels>> GetAllComentAsync(string tourId)
        {          
            var coments = await _db.Comments.Where(x => x.TouristTourId.ToString() == tourId)
                .Select(x => new AllComentsViewModels()
                {
                    Content = x.Content,
                    TourId = x.TouristTourId.ToString(),
                    AppUserName = x.ApplicationUser.UserName ?? "N/A",
                    AppUserId = x.ApplicationUserId.ToString()
                    
                }).ToListAsync();
  
            return coments;
        }

        public async Task<CommentResponseViewModel> GetLatestCommentsAsync(string userId)
        {
           return await _db.Comments.Where(x=>x.ApplicationUserId.ToString()==userId).
                Select(x=>new CommentResponseViewModel() 
                {
                   Content = x.Content,
                   AppUserName = x.ApplicationUser.UserName
                }).FirstOrDefaultAsync();
        }

        
    }
}
