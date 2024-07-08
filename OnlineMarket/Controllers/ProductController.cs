using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineMarket.Models;
using PagedList.Core;
using System.Linq;

namespace OnlineMarket.Controllers
{
    public class ProductController : Controller
    {
        private readonly MarketDbContext _context;

        public ProductController(MarketDbContext context)
        {
            _context = context;
        }

        [Route("shop.html", Name = "ShopProduct")]
        public IActionResult Index(int? page)
        {
            try
            {
                var pageNumber = page == null || page <= 0 ? 1 : page.Value;
                var pageSize = 20;
                var lsProducts = _context.Products.AsNoTracking().OrderByDescending(x => x.CreatedDate);
                PagedList<Product> models = new PagedList<Product>(lsProducts, pageNumber, pageSize);

                ViewBag.CurrentPage = pageNumber;
                return View(models);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [Route("/{Alias}", Name = "ListProduct")]
        public IActionResult List(string Alias, int page=1)
        {
            try
            {
                var pageSize = 20;
                var danhmuc = _context.Categories.AsNoTracking().SingleOrDefault(x => x.Alias == Alias);
                var lsProducts = _context.Products.AsNoTracking().Where(x => x.CategoryId == danhmuc.CategoryId).OrderByDescending(x => x.CreatedDate);
                PagedList<Product> models = new PagedList<Product>(lsProducts, page, pageSize);

                ViewBag.CurrentPage = page;
                ViewBag.CurrentCategory = danhmuc;
                return View(models);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [Route("/{Alias}-{id}.html", Name = "ProductDetails")]
        public IActionResult Details(int id)
        {
            try
            {
                var product = _context.Products.Include(x => x.Category).FirstOrDefault(x => x.ProductId == id);
                if (product == null)
                {
                    return RedirectToAction("Index");
                }
                var lsProducts = _context.Products.AsNoTracking()
                    .Where(x => x.CategoryId == product.CategoryId && x.ProductId != id && x.Active == true)
                    .OrderByDescending(x => x.CreatedDate)
                    .Take(4).ToList();

                ViewBag.SanPham = lsProducts;
                return View(product);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
