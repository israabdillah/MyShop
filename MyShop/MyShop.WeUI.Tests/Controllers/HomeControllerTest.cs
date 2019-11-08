﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyShop.Core.Contracts;
using MyShop.Core.Models;
using MyShop.Core.ViewModels;
using MyShop.WeUI;
using MyShop.WeUI.Controllers;

namespace MyShop.WeUI.Tests.Controllers
{
	[TestClass]
	public class unitest1 
	{
		[TestMethod]
		public void IndexPageDoesReturnProducts()
		{
			IRepository<Product> productContext = new Mocks.MockContext<Product>();
			IRepository<ProductCategory> productCategoryContext = new Mocks.MockContext<ProductCategory>();

			productContext.Insert(new Product());

			HomeController controller = new HomeController(productContext, productCategoryContext);

			var result = controller.Index() as ViewResult;
			var viewModel= (ProductListViewModel)result.ViewData.Model;

			Assert.AreEqual(1, viewModel.Products.Count());
		}
	}
}
