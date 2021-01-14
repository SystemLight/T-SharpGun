using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SharpGun.Pages
{
    public class Home : PageModel
    {
        public string Message = "Hello ";

        public void OnGet([FromQuery] string name) {
            if (string.IsNullOrEmpty(name)) {
                Message += "world";
            }
            else {
                Message += name;
            }
        }
    }
}
