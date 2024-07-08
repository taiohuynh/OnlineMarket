using OnlineMarket.Models;
using System.Collections.Generic;

namespace OnlineMarket.ModelViews
{
    public class HomeModelView
    {
        public List<Post> Posts { get; set; }
        public List<ProductHomeModelView> Products { get; set; }

        //public QuangCao quangcao { get; set; }

    }
}
