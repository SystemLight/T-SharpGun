using System;
using Microsoft.AspNetCore.Mvc;
using SharpGun.Models;
using SharpGun.Services;
using SharpGun.ViewModels;

namespace SharpGun.Controllers.Full
{
    public class HomeFullController : Controller
    {
        /// <summary>
        /// GET /HomeFull/Index
        /// 提供视图处理功能，规定Views文件夹下需要包含HomeFull同名的文件夹，
        /// 文件名称需要与Action保持一致
        /// </summary>
        /// <returns></returns>
        public IActionResult Index() {
            return View();
        }

        /// <summary>
        /// GET /HomeFull/Content
        /// </summary>
        /// <param name="elvesRepository"></param>
        /// <returns></returns>
        public IActionResult Content([FromServices] IElvesRepositoryService elvesRepository) {
            return View(elvesRepository.GetAllElves());
        }

        /// <summary>
        /// GET /HomeFull/ViewModels
        /// </summary>
        /// <param name="elvesRepository"></param>
        /// <returns></returns>
        public IActionResult ViewModels([FromServices] IElvesRepositoryService elvesRepository) {
            var viewModel = new HomeFull
            {
                Elves = elvesRepository.GetAllElves()
            };
            return View(viewModel);
        }

        /// <summary>
        /// GET /HomeFull/Valid
        /// 重定向到另一个Action中
        /// </summary>
        /// <returns></returns>
        public IActionResult Valid() {
            return RedirectToAction("ViewModels");
        }

        [HttpGet]
        public IActionResult Form() {
            return View();
        }

        [HttpPost]
        public IActionResult Form(Elves elves) {
            if (ModelState.IsValid) {
                return Content("验证成功");
            }

            return View();
        }
    }
}
