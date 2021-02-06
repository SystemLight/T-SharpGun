using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SharpGun.Misc.Exceptions;

namespace SharpGun.Controllers
{
    public class ErrorController : ControllerBase
    {
        [Route("/error")]
        public IKnowException HandleError() {
            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var ex = exceptionHandlerPathFeature?.Error;
            var knownException = ex as IKnowException;
            knownException = knownException == null
                ? KnowException.Unknown
                : KnowException.FromKnownException(knownException);
            return knownException;
        }
    }
}
