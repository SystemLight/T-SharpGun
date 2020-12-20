using Microsoft.AspNetCore.Mvc;
using SharpGun.Services;

namespace SharpGun.Controllers.Base
{
    public class HomeController : ControllerBase
    {
        private readonly IElvesRepositoryService _elvesRepository;

        public HomeController(IElvesRepositoryService elvesRepository) {
            _elvesRepository = elvesRepository;
        }

        /// <summary>
        /// GET /Home/Index
        /// 传统基本路由，无视图映射
        /// </summary>
        /// <returns>string</returns>
        public string Index() {
            return "Hello ControllerBase";
        }

        /// <summary>
        /// GET /Home/Object
        /// 返回对象会自动序列化
        /// </summary>
        /// <returns></returns>
        public object Object() {
            return new {msg = "Hello Object"};
        }

        /// <summary>
        /// GET /Home/Content
        /// </summary>
        /// <returns></returns>
        public IActionResult Content() {
            return Content("This is a content!");
        }

        /// <summary>
        /// GET /Home/Elves
        /// 使用通过构造函数依赖注入的服务
        /// </summary>
        /// <returns></returns>
        public IActionResult Elves() {
            return Ok(_elvesRepository.GetAllElves());
        }
    }
}
