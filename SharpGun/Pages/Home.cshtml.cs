using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SharpGun.Services;

namespace SharpGun.Pages
{
    public class Home : PageModel
    {
        // 自动将参数值映射到变量
        // [BindProperty(SupportsGet = true)] public int Id { get; set; }
        public string Message = "Hello ";

        /*
            public IActionResult OnGet() {
                return Redirect("/404");
            }
        */

        /*
            public IActionResult OnGet() {
                return Page();
            }
        */

        /*
            public IActionResult OnGet() {
                return Partial("Shared/Parts/_Show");
            }
        */

        public void OnGet([FromQuery] string name, [FromServices] IReadJsonService service) {
            var config = service.GetConfig();
            if (string.IsNullOrEmpty(name)) {
                Message += config["name"];
            }
            else {
                Message += name;
            }
        }
    }
}
