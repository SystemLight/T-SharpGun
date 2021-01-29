using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;

namespace SharpGun.Controllers.Pure
{
    // [Produces("application/json")]
    [Produces(MediaTypeNames.Text.Plain)]
    [Controller]
    public class HomePureController
    {
        /// <summary>
        /// GET /HomePure/Index
        /// 没有提供任何辅助方法，纯类的控制器
        /// </summary>
        /// <returns></returns>
        public string Index() {
            return "Hello HomePureController";
        }
    }
}
