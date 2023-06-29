using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHome.UI.Areas.Admin.ViewModels.CourseViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHome.UI.Areas.Admin.Controllers;

public class CourseController : Controller
{
    private readonly AppDbContext _context;

    public CourseController(AppDbContext context)
    {
        _context = context;
    }
    [Area("Admin")]
    public async Task<IActionResult> Index()
    {

        List<Course> courses = await _context.Courses.Include(c => c.CourseCatagory).ToListAsync();
        return View(courses);
    }

    [Area("Admin")]
    public async Task<IActionResult> Create()
    {
        ViewBag.Catagories = await _context.CourseCatagories.ToListAsync();
        return View();
    }

    [Area("Admin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CoursePostVM coursePost, int CatagoryId)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var catagory = _context.CourseCatagories.Find(CatagoryId);

        if (catagory is null)
        {
            return BadRequest();
        }

        Course course = new();
        course.Title = coursePost.Title;
        course.Description = coursePost.Description;
        course.ImagePath = coursePost.ImagePath;
        course.CourseCatagoryId = CatagoryId;
        await _context.AddAsync(course);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    

}
