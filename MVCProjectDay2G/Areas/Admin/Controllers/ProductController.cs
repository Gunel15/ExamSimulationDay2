using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCProjectDay2G.DataAccessLayer;
using MVCProjectDay2G.ViewModels.Products;

namespace MVCProjectDay2G.Areas.Admin.Controllers
{
    public class ProductController (Project2DbContext _context): Controller
    {
        public async Task<IActionResult> Index()
        {
            var datas = await _context.Products.Select(x => new ProductListVM
            {
                Title = x.Title,
                Id = x.Id,
                ImageUrl = x.ImageUrl,
                Count = x.Count,
                Rating = x.Rating,
                CategoryId = x.CategoryId,
                CategoryName = x.Category.Name
            }).ToListAsync();
            return View(datas);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Products = await _context.Products.ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateVM vm)
        {
            if (vm.ImageFile != null)
            {
                if(vm.ImageFile)
            }
        }
    }
}
