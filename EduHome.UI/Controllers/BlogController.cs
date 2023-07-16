using EduHome.DataAccess.Contexts;
using EduHome.UI.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHome.UI.Controllers;

public class BlogController : Controller
{
    private readonly AppDbContext _context;

    public BlogController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        HomeVM vm = new()
        {
            Blogs= await _context.Blogs.ToListAsync(),
            CourseCatagorys= await _context.CourseCatagories.ToListAsync()
        };
        return View(vm);
    }

    public async Task<IActionResult> BlogDetail(int id)
    {
        if (id == 0) return NotFound();
        var blog = await _context.Blogs.FindAsync(id);
        if (blog == null) return NotFound();
        ViewBag.BlogId = blog.Id;
        HomeVM vm = new()
        {
            Blogs = await _context.Blogs.ToListAsync(),
            CourseCatagorys = await _context.CourseCatagories.ToListAsync()
        };
        return View(vm);
    }
}
