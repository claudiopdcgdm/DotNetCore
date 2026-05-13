using System.Security.Claims;

namespace Proeventos.API.Extensions
{
    public static class ClaimsPrincipalExtension
    {
        public static string GetUserName(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.Name)?.Value; 
        }
        public static int GetUserId(this ClaimsPrincipal user)
        {
            return int.Parse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            // var claim = user.FindFirst(ClaimTypes.NameIdentifier);

            // if (claim == null)
            //     return null;

            // if (int.TryParse(claim.Value, out var userId))
            //     return userId;

            // return null;
        }
        
    }
}