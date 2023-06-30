using AutoMapper;
using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHome.UI.Areas.Admin.ViewModels.NoticeBoardViewModel;
using EduHome.UI.Areas.Admin.ViewModels.NoticeBoardViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHome.UI.Areas.Admin.Controllers;
[Area("Admin")]
public class NoticeBoardController : Controller
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public NoticeBoardController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    [Area("Admin")]
    public async Task<IActionResult> Index()
    {
        return View(await _context.NoticeBoard.ToListAsync());
    }
    [Area("Admin")]
    public IActionResult Create()
    {
        return View();
    }
    [Area("Admin")]
    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public async Task<IActionResult> Create(NoticeBoardPostVM boardPostVM)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        NoticeBoard notice = _mapper.Map<NoticeBoard>(boardPostVM);
        await _context.NoticeBoard.AddAsync(notice);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    [Area("Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        NoticeBoard? NoticeBoarddb = await _context.NoticeBoard.FindAsync(id);
        if (NoticeBoarddb == null)
        {
            return NotFound();
        }
        return View(NoticeBoarddb);
    }
    [Area("Admin")]
    [HttpPost]
    [ActionName("Delete")]
    [AutoValidateAntiforgeryToken]
    public async Task<IActionResult> DeletePost(int id)
    {
        NoticeBoard? NoticeBoarddb = await _context.NoticeBoard.FindAsync(id);
        if (NoticeBoarddb == null)
        {
            return NotFound();
        }
        _context.NoticeBoard.Remove(NoticeBoarddb);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    [Area("Admin")]
    public async Task<IActionResult> Update(int id)
    {
        NoticeBoard? NoticeBoarddb = await _context.NoticeBoard.FindAsync(id);
        if (NoticeBoarddb == null)
        {
            return NotFound();
        }
        return View(NoticeBoarddb);
    }
    [Area("Admin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(int Id, NoticeBoard NoticeBoard)
    {
        if (Id != NoticeBoard.Id)
        {
            return BadRequest();
        }
        if (!ModelState.IsValid)
        {
            return View(NoticeBoard);
        }
        NoticeBoard? NoticeBoarddb = await _context.NoticeBoard.AsNoTracking().FirstOrDefaultAsync(b => b.Id == Id);
        if (NoticeBoarddb == null)
        {
            return NotFound();
        }
        _context.Entry(NoticeBoard).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
