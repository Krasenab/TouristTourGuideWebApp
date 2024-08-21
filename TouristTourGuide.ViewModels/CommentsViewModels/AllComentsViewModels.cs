using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristTourGuide.ViewModels.CommentsViewModels
{
    public class AllComentsViewModels
    {
        public int Id { get; set; }
        public string TourId { get; set; }
        public string Content { get; set; }
        public string AppUserName { get; set; }    
        public string AppUserId { get; set; }
        public byte[]? AppUserProfilePicture { get; set; }
    }
}
