using OnlineMarket.Models;
using System.Collections.Generic;

namespace OnlineMarket.ModelViews
{
    public class ProductHomeModelView
    {
        public Category category { get; set; }
        public List<Product> lsProducts { get; set; }
    }
}
