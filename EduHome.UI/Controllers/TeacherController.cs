using EduHome.DataAccess.Contexts;
using EduHome.UI.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHome.UI.Controllers;

public class TeacherController : Controller
{
    private readonly AppDbContext _context;

    public TeacherController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        TeacherVM teacherVM = new()
        {
            Teachers= await _context.Teachers.ToListAsync(),
        };
        return View(teacherVM);
    }
}
