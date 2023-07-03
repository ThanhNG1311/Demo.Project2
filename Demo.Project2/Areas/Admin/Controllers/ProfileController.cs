﻿using Demo.Project2.Context;
using Demo.Project2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Security.Principal;

namespace Demo.Project2.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin", AuthenticationSchemes = "AdminSchemes")]
    [Area("admin")]
    [Route("admin/profile")]
    public class ProfileController : Controller
    {
        private readonly DemoProject2DbContext _context;

        public ProfileController(DemoProject2DbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        [Route("index")]
        public async Task<IActionResult> Index()
        {
            var username = User.FindFirstValue(ClaimTypes.Name);
            var user = await _context.Users.FirstOrDefaultAsync(a => a.Username.Equals(username));
            return View(user);
        }

        [HttpGet]
        [Route("updateProfile")]
        public async Task<IActionResult> UpdateProfile()
        {
            var username = User.FindFirstValue(ClaimTypes.Name);
            var user = await _context.Users.FirstOrDefaultAsync(a => a.Username.Equals(username));
            return View("UpdateProfile", user);
        }

        [HttpPost]
        [Route("updateProfile")]
        public async Task<IActionResult> UpdateProfile(User user)
        {
            var currentUser = await _context.Users.FirstOrDefaultAsync(a => a.Id == user.Id);
            currentUser.FullName = user.FullName;
            currentUser.Email = user.Email;
            _context.Update(currentUser);
            await _context.SaveChangesAsync();
            ViewBag.success = "Cập nhật thành công!";
            return View("UpdateProfile", currentUser);
        }

        [HttpGet]
        [Route("updatePassword")]
        public async Task<IActionResult> UpdatePassword()
        {
            var username = User.FindFirstValue(ClaimTypes.Name);
            var user = await _context.Users.FirstOrDefaultAsync(a => a.Username.Equals(username));
            return View("UpdatePassword", user);
        }

        [HttpPost]
        [Route("updatePassword")]
        public async Task<IActionResult> UpdatePassword(User user)
        {
            var currentUser = await _context.Users.FirstOrDefaultAsync(a => a.Id == user.Id);
            if (user.Password.Length < 6)
            {
                ViewBag.error = "Mật khẩu it nhất từ 6 ký tự trở lên";
                return View("UpdatePassword", currentUser);
            }
            currentUser.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            _context.Update(currentUser);
            await _context.SaveChangesAsync();
            ViewBag.success = "Cập nhật thành công!";
            return View("UpdatePassword", currentUser);
        }
    }
}
