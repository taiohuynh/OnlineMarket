using Microsoft.AspNetCore.Mvc;

namespace OnlineMarket.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //"Scaffold-DbContext "Server=TAIOHUYNH;Database=MarketDb;Integrated Security=true;" Microsoft.EntityframeworkCore.SqlServer -OutputDir Models"
            return View();
        }
    }
}
