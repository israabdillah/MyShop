using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using MyShop.Core.Models;

namespace MyShop.DataAccess.InMemory
{
	public class ProductCategoryRepository
	{
		ObjectCache cache = MemoryCache.Default;
		List<ProductCategory> productCategories;

		public ProductCategoryRepository()
		{
			productCategories = cache["productCategories"] as List<ProductCategory>;
			if (productCategories == null)
			{
				productCategories = new List<ProductCategory>();
			}
		}

		public void Commit()
		{
			cache["productCategories"] = productCategories;
		}

		public void Insert(ProductCategory p)
		{
			productCategories.Add(p);
		}

		public void Update(ProductCategory productCategory)
		{
			ProductCategory productCategoryToUpdate = productCategories.Find(p => p.Id == productCategory.Id);

			if (productCategoryToUpdate != null)
			{
				productCategoryToUpdate = productCategory;
			}
			else
			{
				throw new Exception("Product Category Not Found");
			}
		}

		public ProductCategory find(string Id)
		{
			ProductCategory ProductCategory = productCategories.Find(p => p.Id == p.Id);

			if (ProductCategory != null)
			{
				return ProductCategory;
			}
			else
			{
				throw new Exception("Product Category Not Found");
			}
		}

		public IQueryable<ProductCategory> Collection()
		{
			return productCategories.AsQueryable();
		}

		public void Delete(string Id)
		{
			ProductCategory productCategoryToDelete = productCategories.Find(p => p.Id == p.Id);

			if (productCategoryToDelete != null)
			{
				productCategories.Remove(productCategoryToDelete);
			}
			else
			{
				throw new Exception("Product Not Found");
			}
		}
	}
}
