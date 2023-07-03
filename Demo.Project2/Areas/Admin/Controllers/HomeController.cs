﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Project2.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin", AuthenticationSchemes = "AdminSchemes")]
    [Area("admin")]
    [Route("admin")]
    public class HomeController : Controller
    {
        #region Trang chủ quản lý
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
        #endregion Trang chủ quản lý
    }
}
