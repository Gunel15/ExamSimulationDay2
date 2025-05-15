using Microsoft.AspNetCore.Mvc;

namespace MVCProjectDay2G.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
