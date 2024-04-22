using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristTourGuide.ViewModels.CommentsViewModels
{
    public class CommentResponseViewModel
    {
        public string CommentId { get; set; }

        public string Content { get; set; }

        public string AppUserName { get; set; }
       
        public string PostedDate { get; set; }
    }
}
