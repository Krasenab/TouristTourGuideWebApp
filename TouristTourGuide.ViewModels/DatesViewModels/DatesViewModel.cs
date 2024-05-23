using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristTourGuide.ViewModels.DatesViewModels
{
    public class DatesViewModel
    {
        public int Id { get; set; }

        [Required]
        public string ClosedDate { get; set; }


    }
}
