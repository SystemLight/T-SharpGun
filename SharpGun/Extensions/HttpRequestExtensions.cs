using System.Text;
using Microsoft.AspNetCore.Http;

namespace SharpGun.Extensions
{
    public static class HttpRequestExtensions
    {
        /// <summary>
        /// 获取URL绝对路径
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string GetAbsoluteUri(this HttpRequest request) {
            return new StringBuilder()
                .Append(request.Scheme)
                .Append("://")
                .Append(request.Host)
                .Append(request.PathBase)
                .Append(request.Path)
                .Append(request.QueryString)
                .ToString();
        }
    }
}
