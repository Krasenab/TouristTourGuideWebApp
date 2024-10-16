using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristTourGuide.Data.Models.Sql.Models
{
    public class AppUsersTours
    {
        /// <summary>
        /// this is model for db response to favorites tour forech user
        /// </summary>
   

        [ForeignKey(nameof(TouristTourId))]
        public Guid TouristTourId { get; set; }
        public TouristTour TouristTour { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public Guid ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
