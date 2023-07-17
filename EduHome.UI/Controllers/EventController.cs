using EduHome.DataAccess.Contexts;
using EduHome.UI.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHome.UI.Controllers;

public class EventController : Controller
{
    private readonly AppDbContext _context;

    public EventController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        HomeVM vm = new()
        {
            Events= await _context.Events.ToListAsync(),
            EventsDetails = await _context.EventsDetails.ToListAsync(),
            EventSpeakers = await _context.EventSpeakers.ToListAsync(),
        };
        return View(vm);
    }

    public async Task<IActionResult> EventDetail(int id)
    {
        if (id == 0) return NotFound();
        var events = await _context.Events.FindAsync(id);
        if (events == null) return NotFound();
        ViewBag.EventId = events.Id;
        HomeVM vm = new()
        {
            Events = await _context.Events.Include(e=>e.EventDetails).ToListAsync(),
            EventSpeakers= await _context.EventSpeakers.Include(e=>e.Speaker).ToListAsync(),
            CourseCatagorys= await _context.CourseCatagories.ToListAsync()
        };
        return View(vm);
    }
}
