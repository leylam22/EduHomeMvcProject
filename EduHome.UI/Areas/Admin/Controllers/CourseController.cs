using AutoMapper;
using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHome.UI.Areas.Admin.ViewModels.CourseViewModel;
using EduHome.UI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace EduHome.UI.Areas.Admin.Controllers;
[Area("Admin")]
public class CourseController : Controller
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    private readonly ICourseService _courseService;
    public CourseController(AppDbContext context, IMapper mapper, ICourseService courseService)
    {
        _context = context;
        _mapper = mapper;
        _courseService = courseService;
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
        ViewBag.Languages = await _context.Languages.ToListAsync();
        ViewBag.Assesments = await _context.Assesments.ToListAsync();
        ViewBag.SkillLevels = await _context.SkillLevels.ToListAsync();
        return View();
    }

    [Area("Admin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CoursePostVM coursePost)
    {
        if (!ModelState.IsValid)
        {
            //return View(coursePost);
            return BadRequest(ModelState);
        }
        //if(await _courseService.CreateCourseAsync(coursePost)) return BadRequest();
        //await _courseService.CreateCourseAsync(coursePost);
        //return RedirectToAction(nameof(Index));


        var catagory = _context.CourseCatagories.Find(coursePost.CourseCatagoryId);

        if (catagory is null)
        {
            return BadRequest();
        }
        //CourseDetail courseDetail = new()
        //{
        //    courseDetail.Duration= coursePost.Duration,


        //};
        Course course = new();
        course.Title = coursePost.Title;
        course.Description = coursePost.Description;
        course.ImagePath = coursePost.ImagePath;
        course.CourseCatagoryId = coursePost.CourseCatagoryId;

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
        Course? Coursedb = await _context.Courses.Include(cd=>cd.CourseDetail).FirstOrDefaultAsync(a=>a.Id==id);
        ViewBag.Catagories = await _context.CourseCatagories.ToListAsync();
        ViewBag.Languages = await _context.Languages.ToListAsync();
        ViewBag.Assesments = await _context.Assesments.ToListAsync();
        ViewBag.SkillLevels = await _context.SkillLevels.ToListAsync();
        if (Coursedb is null)  return NotFound();
        var CoursVm = _mapper.Map<CoursePostVM>(Coursedb);
        return View(CoursVm);
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
            ViewBag.Catagories = await _context.CourseCatagories.ToListAsync();
            ViewBag.Languages = await _context.Languages.ToListAsync();
            ViewBag.Assesments = await _context.Assesments.ToListAsync();
            ViewBag.SkillLevels = await _context.SkillLevels.ToListAsync();
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
