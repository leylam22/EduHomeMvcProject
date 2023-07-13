using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduHome.UI.Controllers;
[Authorize(Roles ="Member, Admin")]
public class BuyNowController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
