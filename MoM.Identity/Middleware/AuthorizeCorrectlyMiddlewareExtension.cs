using Microsoft.AspNet.Builder;

namespace MoM.Identity.Middleware
{
    public static class AuthorizeCorrectlyMiddlewareExtension
    {
        public static IApplicationBuilder UseAuthorizeCorrectly(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthorizeCorrectlyMiddleware>();
        }
    }
}
