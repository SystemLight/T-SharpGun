using Microsoft.AspNetCore.Mvc;

namespace SharpGun.Controllers.Base
{
    [ApiController]
    [Route("/[Controller]/[Action]")]
    public class ApiController : ControllerBase
    {
        /// <summary>
        /// GET /Api/Index
        /// 1. ApiController修饰后参数绑定策略会自动推断
        /// 2. 模型状态自动验证，否则需要手动调用ModelState.IsValid
        /// 3. 必须配置Route装饰器指定路由
        /// </summary>
        /// <returns></returns>
        public string Index() {
            return "Hello ApiController";
        }
    }
}
