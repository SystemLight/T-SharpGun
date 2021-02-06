using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace SharpGun.Extensions.Middlewares
{
    public static class RouteRewriteMiddlewareExtensions
    {
        public static IApplicationBuilder UseRouteRewrite(this IApplicationBuilder app) {
            return app.UseMiddleware<RouteRewriteMiddleware>();
        }
    }

    public class RouteRewriteMiddleware
    {
        private readonly RequestDelegate _next;

        public RouteRewriteMiddleware(RequestDelegate next) {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context) {
            var path = context.Request.Path.ToUriComponent().ToLowerInvariant();
            if (path.Contains("/proxy")) {
                context.Request.Path = path.Replace("/proxy", "/api");
            }

            await _next.Invoke(context);
        }
    }
}
