using System.Security.Claims;

namespace TouristTourGuide.Infrastrucutre
{
    public static class ClaimPrincipalExtensions
    {
        public static string GetCurrentUserId(this ClaimsPrincipal applicationUser) 
        {
            return applicationUser.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
