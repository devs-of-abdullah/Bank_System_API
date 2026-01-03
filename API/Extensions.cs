    using System.Security.Claims;

namespace API
{
    public static class Extensions
    {
        public static int GetCurrentAccountId(this ClaimsPrincipal account)
        {
            var claim = account.FindFirst(ClaimTypes.NameIdentifier);

            if (claim == null)
                throw new UnauthorizedAccessException("Current account not found");

            return int.Parse(claim.Value);
        }
    }

}
   


