using EduHome.DataAccess.Contexts;
using EduHome.UI.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHome.UI.Controllers;

public class CourseController : Controller
{
    private readonly AppDbContext _context;

    public CourseController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        HomeVM vm = new()
        {
            Courses= await _context.Courses.ToListAsync(),
            CourseDetails =await _context.CourseDetails.ToListAsync(),
            CourseCatagorys= await _context.CourseCatagories.ToListAsync()
        };
        return View(vm);
    }

    public async Task<IActionResult> CourseDetail(int id)
    {
        if (id == 0) return NotFound();
        var course = await _context.Courses.FindAsync(id);
        if (course == null) return NotFound();
        ViewBag.CourseId = course.Id;
        HomeVM vm = new()
        {
            Courses = await _context.Courses.Include(c => c.CourseDetail).ToListAsync(),
            CourseDetails = await _context.CourseDetails.ToListAsync(),
            CourseCatagorys = await _context.CourseCatagories.ToListAsync()
        };
        return View(vm);
    }
}
