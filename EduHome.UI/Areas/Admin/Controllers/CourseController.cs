using AutoMapper;
using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHome.UI.Areas.Admin.ViewModels.CourseViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace EduHome.UI.Areas.Admin.Controllers;

public class CourseController : Controller
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    public CourseController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
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

    [Area("Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        Course? Coursedb = await _context.Courses.FindAsync(id);
        if (Coursedb == null)
        {
            return NotFound();
        }
        return View(Coursedb);
    }
    [Area("Admin")]
    [HttpPost]
    [ActionName("Delete")]
    [AutoValidateAntiforgeryToken]
    public async Task<IActionResult> DeletePost(int id)
    {
        Course? Coursedb = await _context.Courses.FindAsync(id);
        if (Coursedb == null)
        {
            return NotFound();
        }
        _context.Courses.Remove(Coursedb);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    [Area("Admin")]
    public async Task<IActionResult> Update(int id)
    {
        Course? Coursedb = await _context.Courses.FindAsync(id);
        if (Coursedb == null)
        {
            return NotFound();
        }
        ViewBag.Catagories = await _context.CourseCatagories.ToListAsync();
        return View(Coursedb);
    }
    [Area("Admin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(int Id, Course Course)
    {
        if (Id != Course.Id)
        {
            return BadRequest();
        }
        if (!ModelState.IsValid)
        {
            //return View(Course);
            ViewBag.Catagories = await _context.CourseCatagories.ToListAsync();
            return View(Course);
        }
        Course? Coursedb = await _context.Courses.AsNoTracking().FirstOrDefaultAsync(c => c.Id == Id);
        if (Coursedb == null)
        {
            return NotFound();
        }
        _context.Entry(Course).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

}
