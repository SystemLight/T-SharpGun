using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;

namespace SharpGun.Extensions
{
    public static class SayHelloMiddlewareExtensions
    {
        public static IApplicationBuilder UseSayHello(this IApplicationBuilder app) {
            return app.UseMiddleware<SayHelloMiddleware>();
        }
    }

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
