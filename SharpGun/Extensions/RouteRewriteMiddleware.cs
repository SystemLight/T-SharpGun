using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Suit2.Extensions;

namespace Microsoft.AspNetCore.Builder
{
    public static class RouteRewriteMiddlewareExtensions
    {
        public static IApplicationBuilder UseRouteRewrite(this IApplicationBuilder app) {
            return app.UseMiddleware<RouteRewriteMiddleware>();
        }
    }
}

namespace Suit2.Extensions
{
    public class RouteRewriteMiddleware
    {
        private readonly RequestDelegate _next;

        public RouteRewriteMiddleware(RequestDelegate next) {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context) {
            var path = context.Request.Path.ToUriComponent().ToLowerInvariant();
            Console.WriteLine(path);
            if (path.Contains("/redirect")) {
                context.Request.Path = "/api/index";
            }

            await _next(context);
        }
    }
}
