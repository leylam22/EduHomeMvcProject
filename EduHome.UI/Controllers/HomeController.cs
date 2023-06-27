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
<<<<<<< HEAD
                Sliders=await _context.Sliders.ToListAsync(),
=======
>>>>>>> 83538c1a215db16639e5e0d75d974bbdc596408a
            };
            return View(homevm);
        }
    }
}
