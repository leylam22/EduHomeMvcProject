using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHome.UI.Areas.Admin.ViewModels.SliderViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHome.UI.Areas.Admin.Controllers;
[Area("Admin")]
public class SliderController : Controller
{
    private readonly AppDbContext _context;

    public SliderController(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        return View(await _context.Sliders.ToListAsync());
    }
    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public async Task<IActionResult> Create(SliderPostVM sliderPostVM)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        Slider slider = new()
        {
            Title = sliderPostVM.Title,
            Description = sliderPostVM.Description,
            SecondTitle = sliderPostVM.SecondTitle,
            //Offer = sliderPostVM.Offer,            burda secondTitle olacaq
            Image = sliderPostVM.Image,
        };
        await _context.Sliders.AddAsync(slider);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        Slider? sliderdb = await _context.Sliders.FindAsync(id);
        if (sliderdb == null)
        {
            return NotFound();
        }
        return View(sliderdb);
    }

    [HttpPost]
    [ActionName("Delete")]
    [AutoValidateAntiforgeryToken]
    public async Task<IActionResult> DeletePost(int id)
    {
        Slider? sliderdb = await _context.Sliders.FindAsync(id);
        if (sliderdb == null)
        {
            return NotFound();
        }
        _context.Sliders.Remove(sliderdb);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
