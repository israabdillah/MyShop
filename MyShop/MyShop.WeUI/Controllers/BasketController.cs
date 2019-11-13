using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyShop.Contracts;
using MyShop.Core.Contracts;
using MyShop.Core.Models;
using MyShop.Services;

namespace MyShop.WeUI.Controllers
{

	public class BasketController : Controller
	{
		IEBasketService basketService;
		IOrderService orderService;
		IRepository<Customer> customers;

		public BasketController(IEBasketService BasketService, IOrderService OrderService, IRepository<Customer> Customers) {
			basketService = BasketService;
			orderService = OrderService;
			customers = Customers;
		}
		// GET: Basket
		public ActionResult Index()
		{
			var model = basketService.GetBasketItems(HttpContext);
			return View(model);
		}

		public ActionResult AddToBasket(string Id) 
		{
			basketService.AddToBasket(HttpContext, Id);
			return RedirectToAction("Index");
		}

		public ActionResult RemoveFromBasket(string Id)
		{
			basketService.RemoveFromBasket(this.HttpContext, Id);

			return RedirectToAction("Index");
		}

		public PartialViewResult BasketSummary() {
			var basketSummary = basketService.GetBasketSummary(this.HttpContext);

			return PartialView(basketSummary);
		}
		[Authorize]
		public ActionResult Checkout() {
			Customer customer = customers.Collection().FirstOrDefault(c => c.Email == User.Identity.Name);

			if (customer == null)
			{
				Order order = new Order()
				{
					Email = customer.Email,
					City = customer.City,
					State = customer.State,
					Street = customer.Street,
					FirstName = customer.FirstName,
					Surname = customer.LastName,
					ZipCode = customer.ZipCode

				};
				return View(order);
			}
			else
			{
				return RedirectToAction("Error");
			}
		}

		[HttpPost]
		[Authorize]
		public ActionResult Checkout(Order order) {
			var basketItems = basketService.GetBasketItems(this.HttpContext);
			order.OrderStatus = "Order Created";
			order.Email = User.Identity.Name;

			//Process Payment

			order.OrderStatus = "Payment Proccesed";
			orderService.CreateOrder(order, basketItems);
			basketService.ClearBasket(this.HttpContext);

			return RedirectToAction("Thankyou", new { OrderId = order.Id });
		}

		public ActionResult Thankyou(string OrderId) {
			ViewBag.OrderId = OrderId;
			return View();
		}
	}
}