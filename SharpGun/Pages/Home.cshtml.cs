using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SharpGun.Pages
{
    public class Home : PageModel
    {
        // 自动将参数值映射到变量
        // [BindProperty(SupportsGet = true)] public int Id { get; set; }
        public string Message = "Hello ";

        // public void OnGet([FromQuery] string name) {
        //     if (string.IsNullOrEmpty(name)) {
        //         Message += "world";
        //     }
        //     else {
        //         Message += name;
        //     }
        // }

        public IActionResult OnGeet() {
            var partialView = new PartialViewResult();
            partialView.ViewName = "Shared/Parts/_Show";
            return partialView;
        }
    }
}
