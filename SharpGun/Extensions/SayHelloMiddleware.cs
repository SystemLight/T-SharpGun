using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SharpGun.Extensions;

namespace Microsoft.AspNetCore.Builder
{
    public static class SayHelloMiddlewareExtensions
    {
        public static IApplicationBuilder UseSayHello(this IApplicationBuilder app) {
            return app.UseMiddleware<SayHelloMiddleware>();
        }
    }
}

namespace SharpGun.Extensions
{
    public class SayHelloMiddleware
    {
        private readonly RequestDelegate _next;

        public SayHelloMiddleware(RequestDelegate next) {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context) {
            await context.Response.WriteAsync("hello middleware");
        }
    }
}
