using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristTourGuide.Data;
using TouristTourGuide.Data.Models.Sql.Models;
using TouristTourGuide.Services.Interfaces;

namespace TouristTourGuide.Services
{
    public class CommentsService : ICommentsService
    {
        private TouristTourGuideDbContext _db;
        public CommentsService(TouristTourGuideDbContext dbContext)
        {
                _db= dbContext; 
        }
        public async Task Create(string tourId, string content, string appUserId)
        {
            //Comments c = new Comments() 
            //{
            //    TouristTourId = Guid.Parse(tourId),
            //    Content = content,
            //    ApplicationUserId = Guid.Parse(appUserId)
            //};
            //await _db.Comments.AddAsync(c);
            await _db.SaveChangesAsync();

        }
    }
}
