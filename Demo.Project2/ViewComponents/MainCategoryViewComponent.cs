﻿using Demo.Project2.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo.Project2.ViewComponents
{
    public class MainCategoryViewComponent : ViewComponent
    {
        private readonly DemoProject2DbContext _context;

        public MainCategoryViewComponent(DemoProject2DbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _context.Categories
                .Where(a => a.Status == true && a.ParentCategory == null)
                .ToListAsync();
            return View("index", categories);
        }
    }
}