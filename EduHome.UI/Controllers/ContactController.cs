using Microsoft.AspNetCore.Mvc;

namespace EduHome.UI.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
