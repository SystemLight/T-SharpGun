using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SharpGun.Extensions;

namespace Microsoft.AspNetCore.Builder
{
    public static class ProxyMiddlewareExtensions
    {
        public static IApplicationBuilder UseProxy(this IApplicationBuilder app) {
            return app.UseMiddleware<ProxyMiddleware>();
        }
    }
}

namespace SharpGun.Extensions
{
    public class ProxyMiddleware
    {
        private readonly RequestDelegate _next;
        private static readonly HttpClient Http = new HttpClient();

        public ProxyMiddleware(RequestDelegate next) {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context) {
            var url = context.Request.Path.ToUriComponent();
            var uri = new Uri("http://192.168.52.23:5002" + url);

            var request = CopyRequest(context, uri);
            var remoteRsp = await Http.SendAsync(request);
            var rsp = context.Response;

            foreach (var (key, value) in remoteRsp.Headers) {
                rsp.Headers.Add(key, value.ToArray());
            }

            rsp.ContentType = remoteRsp.Content.Headers.ContentType?.ToString() ?? string.Empty;
            rsp.ContentLength = remoteRsp.Content.Headers.ContentLength;

            await remoteRsp.Content.CopyToAsync(rsp.Body);
        }

        private static HttpRequestMessage CopyRequest(HttpContext context, Uri targetUri) {
            var req = context.Request;
            var requestMessage = new HttpRequestMessage
            {
                Method = new HttpMethod(req.Method),
                Content = new StreamContent(req.Body),
                RequestUri = targetUri,
            };
            foreach (var (key, value) in req.Headers) {
                requestMessage.Content?.Headers.TryAddWithoutValidation(key, value.ToArray());
            }

            requestMessage.Headers.Host = targetUri.Host;
            return requestMessage;
        }
    }
}
