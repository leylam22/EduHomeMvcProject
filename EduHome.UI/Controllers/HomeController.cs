﻿using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHome.UI.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHome.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            HomeVM homevm = new()
            {
                Blogs=await _context.Blogs.ToListAsync(),
                Sliders=await _context.Sliders.ToListAsync(),
                Courses=await _context.Courses.ToListAsync(),
                CourseCatagorys=await _context.CourseCatagories.ToListAsync(),
                NoticeBoard=await _context.NoticeBoard.ToListAsync(),
                Events=await _context.Events.ToListAsync(),
                Testimonials=await _context.Testimonials.ToListAsync()
            };
            return View(homevm);
        }
    }
}
