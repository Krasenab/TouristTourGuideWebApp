using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristTourGuide.Services.Interfaces
{
    public interface ICommentsService
    {
        Task Create(string tourId,string content,string appUserId);
    }
}
