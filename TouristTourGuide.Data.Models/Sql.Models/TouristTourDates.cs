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
        [ForeignKey(nameof(TouristTourId))]
        public Guid TouristTourId { get; set; }
        public virtual TouristTour TouristTour { get; set; }
        [ForeignKey(nameof(ClosedDatesId))]
        public int ClosedDatesId { get; set; }
        public Dates ClosedDates { get; set; }
    }
}
