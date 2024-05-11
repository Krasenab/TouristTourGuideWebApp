using System.Security.Claims;

namespace TouristTourGuide.Infrastrucutre
{
    public static class ClaimPrincipalExtensions
    {
        public static string GetCurrentUserId(this ClaimsPrincipal applicationUser)
        {
            string currentUser = applicationUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            return currentUser;
        }
        public static bool IsAdmin(this ClaimsPrincipal applicationUser)
        {
            return applicationUser.IsInRole("Administrator");
        }
    }
}
