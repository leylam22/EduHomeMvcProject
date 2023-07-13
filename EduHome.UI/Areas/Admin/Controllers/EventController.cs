using AutoMapper;
using EduHome.Core.Entities;
using EduHome.Core.Utilites;
using EduHome.DataAccess.Contexts;
using EduHome.UI.Areas.Admin.ViewModels.EventViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static EduHome.Core.Utilites.UserRole;

namespace EduHome.UI.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles = UserRole.Admin)]

public class EventController : Controller
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public EventController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.Events.ToListAsync());
    }
    public IActionResult Create()
    {
        return View();
    }
    [Area("Admin")]
    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public async Task<IActionResult> Create(EventPostVM eventPostVM)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        Event events = _mapper.Map<Event>(eventPostVM);
        await _context.Events.AddAsync(events);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        Event? Eventdb = await _context.Events.FindAsync(id);
        if (Eventdb == null)
        {
            return NotFound();
        }
        return View(Eventdb);
    }

    [HttpPost]
    [ActionName("Delete")]
    [AutoValidateAntiforgeryToken]
    public async Task<IActionResult> DeletePost(int id)
    {
        Event? Eventdb = await _context.Events.FindAsync(id);
        if (Eventdb == null)
        {
            return NotFound();
        }
        _context.Events.Remove(Eventdb);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Update(int id)
    {
        Event? Eventdb = await _context.Events.FindAsync(id);
        if (Eventdb == null)
        {
            return NotFound();
        }
        return View(Eventdb);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(int Id, Event events)
    {
        if (Id != events.Id)
        {
            return BadRequest();
        }
        if (!ModelState.IsValid)
        {
            return View(events);
        }
        Event? Eventdb = await _context.Events.AsNoTracking().FirstOrDefaultAsync(b => b.Id == Id);
        if (Eventdb == null)
        {
            return NotFound();
        }
        _context.Entry(events).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
