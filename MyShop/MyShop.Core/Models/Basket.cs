using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
	public class Basket : BaseEntity
	{
		public virtual ICollection<BasketItem> BasketItems { get; set; }

		public Basket() {
			BasketItems = new List<BasketItem>();
		}
		public string BasketId { get; set; }
		public string ProductId { get; set; }
		public string Name { get; set; }
		public int Quanity { get; set; }
	}
}
