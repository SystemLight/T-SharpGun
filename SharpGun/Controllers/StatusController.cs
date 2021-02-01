using Microsoft.AspNetCore.Mvc;

namespace SharpGun.Controllers
{
    [Route("/Status")]
    public class StatusController : ControllerBase
    {
        [HttpGet("{code}")]
        public IActionResult Index(string code) {
            return Ok(new {statusCode = code});
        }
    }
}
