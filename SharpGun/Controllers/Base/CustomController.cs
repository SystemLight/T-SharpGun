using Microsoft.AspNetCore.Mvc;

namespace SharpGun.Controllers.Base
{
    [Route("/[Controller]")]
    public class CustomController : ControllerBase
    {
        /// <summary>
        /// GET /Home/Custom
        /// 可以通过Route装饰注册自定义路径
        /// </summary>
        /// <returns></returns>
        [Route("Custom")]
        public string Index() {
            return "Hello CustomController";
        }

        /// <summary>
        /// GET /Home/Object
        /// 可以使用[Action]占位路由
        /// </summary>
        /// <returns></returns>
        [Route("[Action]")]
        public object Object() {
            return new {msg = "Hello Object"};
        }
    }
}
