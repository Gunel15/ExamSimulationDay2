using Microsoft.AspNetCore.Mvc;

namespace MVCProjectDay2G.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
