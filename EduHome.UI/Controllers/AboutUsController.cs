using EduHome.DataAccess.Contexts;
using EduHome.UI.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHome.UI.Controllers
{
    public class AboutUsController : Controller
    {
        private readonly AppDbContext _context;

        public AboutUsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            HomeVM vm = new()
            {
                AboutUses = await _context.AboutUses.ToListAsync(),
                Teachers= await _context.Teachers.ToListAsync(),
                NoticeBoard= await _context.NoticeBoard.ToListAsync(),
                Testimonials= await _context.Testimonials.ToListAsync()
            };
            return View(vm);
        }
    }
}
