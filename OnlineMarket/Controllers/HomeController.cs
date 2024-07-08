using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineMarket.Models;
using OnlineMarket.ModelViews;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMarket.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MarketDbContext _context;
        public HomeController(ILogger<HomeController> logger, MarketDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            HomeModelView model = new HomeModelView();
            var lsProducts = _context.Products.AsNoTracking().Where(x => x.Active == true && x.HomeFlag == true)
                .ToList();

            List<ProductHomeModelView> lsProductViews = new List<ProductHomeModelView>();
            var lsCategories = _context.Categories.AsNoTracking().Where(x => x.Published == true)
                .ToList();

            foreach(var item in lsCategories)
            {
                ProductHomeModelView productHome = new ProductHomeModelView();
                productHome.category = item;
                productHome.lsProducts = lsProducts.Where(x => x.CategoryId == item.CategoryId).ToList();
                lsProductViews.Add(productHome);
            }

            //var quangcao = _context.QuangCao.AsNoTracking().FirstOrDefault(x => x.Active == true);

            //var posts = _context.Posts.AsNoTracking()
            //    .Where(x => x.Published == true && x.IsNewfeed == true)
            //    .OrderByDescending(x => x.CreatedDate).Take(3).ToList();

            model.Products = lsProductViews;
            //model.Posts = posts;
            ViewBag.AllProducts = lsProducts;
            return View(model);
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
