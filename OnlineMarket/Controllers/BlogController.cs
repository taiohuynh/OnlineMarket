using Microsoft.AspNetCore.Mvc;

namespace OnlineMarket.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
