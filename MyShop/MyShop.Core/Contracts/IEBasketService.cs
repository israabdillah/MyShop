using System.Collections.Generic;
using System.Web;
using MyShop.Core.ViewModels;

namespace MyShop.Contracts
{
	public interface IEBasketService
	{
		void AddToBasket(HttpContextBase httpContext, string productId);
		void ClearBasket(HttpContextBase httpContext);
		List<BasketItemViewModel> GetBasketItems(HttpContextBase httpContext);
		BasketSummaryViewModel GetBasketSummary(HttpContextBase httpContext);
		void RemoveFromBasket(HttpContextBase httpContext, string itemId);
	}
}