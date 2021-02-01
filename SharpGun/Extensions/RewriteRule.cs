using System;
using System.Net;
using Microsoft.AspNetCore.Rewrite;

namespace SharpGun.Extensions
{
    public class RewriteRule : IRule
    {
        /// <summary>
        /// 自定义重定向规则
        /// </summary>
        /// <param name="context"></param>
        public void ApplyRule(RewriteContext context) {
            var request = context.HttpContext.Request;
            var host = request.Host;
            if (host.Host.Contains("localhost", StringComparison.OrdinalIgnoreCase)) {
                if (host.Port == 80) {
                    context.Result = RuleResult.ContinueRules;
                    return;
                }
            }

            var response = context.HttpContext.Response;
            response.StatusCode = (int) HttpStatusCode.BadRequest;
            context.Result = RuleResult.EndResponse;
        }
    }
}
