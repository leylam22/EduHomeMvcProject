﻿using EduHome.DataAccess.Contexts;
using EduHome.UI.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHome.UI.Controllers;

public class TeacherDetailController : Controller
{
    private readonly AppDbContext _context;

    public TeacherDetailController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(int id)
    {
        if (id == 0) return BadRequest();
        var teacher = await _context.Teachers.FindAsync(id);
        if (teacher == null)
        {
            return NotFound();
        }
        ViewBag.TeacherId=teacher.Id;
        TeacherVM teacherVM = new()
        {
            Teachers= await _context.Teachers.Include(td=>td.teacherDetails).ToListAsync(),
        };
        return View(teacherVM);
    }
}
