using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineMarket.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineMarket.Areas.Admin.Controllers
{
    [Area("Admin")]


    public class SearchController : Controller
    {
        private readonly MarketDbContext _context;
        public SearchController(MarketDbContext context)
        {
            _context = context;
        }

        //GET: Search/FindProduct
        [HttpPost]
        public IActionResult FindProduct(string keyword)
        {
            List<Product> ls = new List<Product>();
            if (string.IsNullOrEmpty(keyword) || keyword.Length < 1)
                return PartialView("ListProductsSearchPartial", null);
            ls = _context.Products.AsNoTracking().Include(a => a.Category)
                .Where(x => x.ProductName
                .Contains(keyword)).OrderByDescending(x => x.ProductName)
                .Take(10).ToList();
            if (ls == null)
                return PartialView("ListProductsSearchPartial", null);
            else
                return PartialView("ListProductsSearchPartial", ls);
        }
    }
}