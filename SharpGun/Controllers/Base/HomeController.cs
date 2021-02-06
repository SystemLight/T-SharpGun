using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharpGun.Misc.Filters;
using SharpGun.Services;

namespace SharpGun.Controllers.Base
{
    public class HomeController : ControllerBase
    {
        private readonly IElvesRepositoryService _elvesRepository;
        private readonly IHelloAopService _helloAopService;

        public HomeController(
            IEnumerable<IElvesRepositoryService> elvesRepositoryServices,
            IElvesRepositoryService elvesRepository,
            IHelloAopService helloAopService
        ) {
            _elvesRepository = elvesRepository;
            _helloAopService = helloAopService;
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
        [Authorize]
        public IActionResult Content() {
            return Content("This is a content!");
        }

        /// <summary>
        /// GET /Home/Elves
        /// 使用通过构造函数依赖注入的服务
        /// </summary>
        /// <returns></returns>
        [TypeFilter(typeof(MyActionFilterAttribute))]
        public IActionResult Elves() {
            return Ok(_elvesRepository.GetAllElves());
        }

        /// <summary>
        /// GET /Home/Aop
        /// Autofac面向切片服务注入
        /// </summary>
        /// <returns></returns>
        public IActionResult Aop() {
            _helloAopService.SayHello();
            return Ok("Aop");
        }

        /// <summary>
        /// GET /Home/Login
        /// </summary>
        /// <returns></returns>
        public IActionResult Login() {
            var claimsPrincipal = new ClaimsPrincipal( // 身份证持有者
                new ClaimsIdentity( // 声明主体，代表一个认证用户的身份证
                    new List<Claim>
                    {
                        new(ClaimTypes.Role, "Admin"), // 认证用户身份的元数据信息
                        new(ClaimTypes.Name, "Admin"),
                        new("Password", "Admin"),
                        new("Account", "Admin"),
                        new("role", "Admin")
                    },
                    "Customer"
                )
            );
            HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                claimsPrincipal,
                new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(30)
                }
            );
            return Ok("Login");
        }
    }
}
