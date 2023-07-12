using EduHome.DataAccess.Contexts;
using EduHome.UI.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHome.UI.Controllers;

public class CourseDetailController : Controller
{
    private readonly AppDbContext _context;

    public CourseDetailController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(int id)
    {
        if(id == 0) return NotFound();
        var course = await _context.Courses.FindAsync(id);
        if(course == null) return NotFound();
        ViewBag.CourseId = course.Id;
        HomeVM vm = new()
        {
            Courses = await _context.Courses.Include(c=>c.CourseDetail).ToListAsync(),
            CourseDetails = await _context.CourseDetails.ToListAsync(),
            CourseCatagorys = await _context.CourseCatagories.ToListAsync()
        };
        return View(vm);
    }
}
