using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCProjectDay2G.DataAccessLayer;
using MVCProjectDay2G.Models;
using MVCProjectDay2G.ViewModels.Products;

namespace MVCProjectDay2G.Areas.Admin.Controllers
{
    [Area("Admin")]
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
                if (!vm.ImageFile.ContentType.StartsWith("image"))
                    ModelState.AddModelError("ImageFile", "File format must be image");
                if(vm.ImageFile.Length/1024>200)
                    ModelState.AddModelError("ImageFile", "File size must be less than 200kb");

            }
            if (!ModelState.IsValid)
            { ViewBag.Category = await _context.Categories.ToListAsync();
                return View(vm);
            }

            if (!await _context.Products.AnyAsync(x => x.Id == vm.CategoryId))
            {
                ModelState.AddModelError("CategoryId", "Category with this Id Does not exit");
                ViewBag.Products = await _context.Products.ToListAsync();
                return View(vm);
            }

            string newImgName = Guid.NewGuid().ToString() + vm.ImageFile!.FileName;
            string path=Path.Combine("wwwroot","imgs","products",newImgName);
            await using(FileStream fs=new FileStream(path, FileMode.Create))
            {
                await vm.ImageFile.CopyToAsync(fs);
            }

            Product product = new Product
            {
                Title = vm.Title,
                Count = vm.Count,
                Rating = vm.Rating,
                CategoryId = vm.CategoryId,
                ImageUrl = newImgName
            };
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (!id.HasValue || id.Value < 1)
                return BadRequest();
            if(ModelState.IsValid) 
                return NotFound();
            var entity = await _context.Products.Where(x => x.Id == id).Select(x => new ProductUpdateVM
            {
                Title = x.Title,
                Count = x.Count,
                Rating = x.Rating,
                CategoryId = x.CategoryId,
                ImageUrl = x.ImageUrl
            }).FirstOrDefaultAsync();
            if (entity == null)
                return NotFound();
            return View(entity);
        }

        //public async Task<IActionResult>Update(int? id, ProductUpdateVM vm)
        //{

        //}
    }
}
