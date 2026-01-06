using System.Security.Claims;

namespace ERP.API.Extensions
{
    public static class HttpContextExtensions
    {
        public static int GetUserId(this HttpContext context)
        {
            var userIdClaim = context.User.FindFirst(ClaimTypes.NameIdentifier)
                               ?? context.User.FindFirst("sub");

            return int.Parse(userIdClaim!.Value);
        }
    }
}
