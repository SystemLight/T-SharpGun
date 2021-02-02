using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace SharpGun.Extensions
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
            var thingId = context.Request.Query["thingId"].ToString();

            if (path.Contains("/lockweb")) {
                var templateController = GetControllerByThingId(thingId);

                context.Request.Path = path.Replace("lockweb", templateController);
            }

            //Let the next middleware (MVC routing) handle the request
            //In case the path was updated, the MVC routing will see the updated path
            await _next.Invoke(context);
        }

        private string GetControllerByThingId(string thingId) {
            //some logic
            return "yinhua";
        }
    }
}
