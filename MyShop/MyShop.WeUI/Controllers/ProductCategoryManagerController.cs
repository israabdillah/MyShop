﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyShop.Core.Models;
using MyShop.DataAccess.InMemory;

namespace MyShop.WeUI.Controllers
{
    public class ProductCategoryManagerController : Controller
    {
		ProductCategoryRepository context;

		public ProductCategoryManagerController()
		{
			context = new ProductCategoryRepository();
		}
		// GET: ProductManager
		public ActionResult Index()
		{
			List<ProductCategory> productCategories = context.Collection().ToList();
			return View(productCategories);
		}

		public ActionResult Create()
		{
			ProductCategory productCategory = new ProductCategory();
			return View(productCategory);
		}
		[HttpPost]
		public ActionResult Create(ProductCategory productCategory)
		{

			if (!ModelState.IsValid)
			{
				return View(productCategory);
			}
			else
			{
				context.Insert(productCategory);
				context.Commit();

				return RedirectToAction("Index");
			}
		}

		public ActionResult Edit(string Id)
		{
			ProductCategory productCategory = context.find(Id);
			if (productCategory == null)
			{
				return HttpNotFound();
			}
			else
			{
				return View(productCategory);
			}
		}
		[HttpPost]
		public ActionResult Edit(ProductCategory productCategory, string Id)
		{
			ProductCategory productCategoryToEdit = context.find(Id);
			if (productCategoryToEdit == null)
			{
				return HttpNotFound();
			}
			else
			{
				if (!ModelState.IsValid)
				{
					return View(productCategory);
				}
				else
				{
					productCategoryToEdit.Category = productCategory.Category;

					context.Commit();

					return RedirectToAction("Index");
				}
			}
		}
		public ActionResult Delete(string Id)
		{
			ProductCategory productCategoryToDelete = context.find(Id);
			if (productCategoryToDelete == null)
			{
				return HttpNotFound();

			}
			else
			{
				return View(productCategoryToDelete);
			}
		}
		[HttpPost]
		[ActionName("Delete")]
		public ActionResult ConfirmDelete(string Id)
		{
			ProductCategory productCategoryToDelete = context.find(Id);
			if (productCategoryToDelete == null)
			{
				return HttpNotFound();

			}
			else
			{
				context.Delete(Id);
				context.Commit();
				return RedirectToAction("Index");
			}
		}
	}
}