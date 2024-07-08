using OnlineMarket.Models;
using System.Collections.Generic;

namespace OnlineMarket.ModelViews
{
	public class OrderDetailModelView
	{
		public Order DonHang { get; set; }
		public List<OrderDetail> ChiTietDonHang { get; set; }
	}
}
