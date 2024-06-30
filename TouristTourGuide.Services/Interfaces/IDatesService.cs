using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristTourGuide.Services.Interfaces
{
    public interface IDatesService
    {
        Task CreateTourClosedDate(string tourId,string dates);
        Task<bool> IsDateClosed(string tourId,string date);
   
    }
}
