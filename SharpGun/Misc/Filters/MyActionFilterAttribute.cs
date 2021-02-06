using System;
using Microsoft.AspNetCore.Mvc.Filters;
using SharpGun.Services;

namespace SharpGun.Misc.Filters
{
    public class MyActionFilterAttribute : ActionFilterAttribute
    {
        public MyActionFilterAttribute(IHelloAopService service) {
            service.SayHello();
        }

        public override void OnActionExecuting(ActionExecutingContext context) {
            // 跳过标记AllowAnonymous特性的内容
            // context.ActionDescriptor.EndpointMetadata.Any(item => item is AllowAnonymous);

            Console.WriteLine("OnActionExecuting");
        }

        public override void OnActionExecuted(ActionExecutedContext context) {
            Console.WriteLine("OnActionExecuted");
        }
    }
}
