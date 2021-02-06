using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SharpGun.Extensions.Razor.Contents
{
    public static class HelloHtmlHelperExtensions
    {
        public static IHtmlContent Hello(this IHtmlHelper helper) {
            return new HtmlString("<h1>Hello</h1>");
        }
    }
}
