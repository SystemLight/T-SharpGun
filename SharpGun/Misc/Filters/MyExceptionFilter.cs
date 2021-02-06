using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SharpGun.Misc.Exceptions;

namespace SharpGun.Misc.Filters
{
    public class MyExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context) {
            var knownException = context.Exception as IKnowException;
            knownException = knownException == null
                ? KnowException.Unknown
                : KnowException.FromKnownException(knownException);
            context.Result = new JsonResult(knownException)
            {
                ContentType = "application/json;charset=utf-8",
            };
        }
    }
}
