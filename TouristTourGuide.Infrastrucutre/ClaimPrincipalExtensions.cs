using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace TouristTourGuide.Infrastrucutre
{
    public static class ClaimPrincipalExtensions
    {
        public static string GetCurrentUserId(this ClaimsPrincipal applicationUser) 
        {
            
            string currentUser =  applicationUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            return currentUser;
        }
    }
}
