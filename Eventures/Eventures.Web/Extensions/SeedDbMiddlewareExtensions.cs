using Eventures.Web.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Eventures.Web.Extensions
{
    public static class SeedDbMiddlewareExtensions
    {
        public static IApplicationBuilder UseSeedDb(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SeedDbMiddleware>();
        }
    }
}