using Microsoft.AspNetCore.Mvc;

namespace LyMapFood.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}