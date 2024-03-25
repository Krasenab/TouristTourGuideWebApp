using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristTourGuide.Data.Models.Sql.Models
{
    public class TouristTourDates
    {
        public Guid TouristTourId { get; set; }
        public virtual TouristTour TouristTour { get; set; }
        public int DatesId { get; set; }
        public Dates Dates { get; set; }
    }
}
