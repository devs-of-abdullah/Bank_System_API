    using System.Security.Claims;

namespace API
{
    public static class Extensions
    {
        public static int GetCurrentUserId(this ClaimsPrincipal user)
        {
            var claim = user.FindFirst(ClaimTypes.NameIdentifier);

            if (claim == null)
                throw new UnauthorizedAccessException("Current user not found");

            return int.Parse(claim.Value);
        }
    }

}
   


