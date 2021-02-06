using Microsoft.AspNetCore.Mvc;

namespace SharpGun.Extensions.Razor.Components
{
    [ViewComponent(Name = "Hello")]
    public class HelloComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string searchKey) {
            return View();
        }
    }
}
