using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectMiniShop.Data;
using ProjectMiniShop.ViewModel;

namespace ProjectMiniShop.Controllers
{
	public class ProductController (ApplicationDbContext _db): Controller
	{
		public IActionResult Index(int? Page)
		{
			if (Page  == null) 
			{
				Page = 1;
			}
			int NoOfSkiproducts =(int) (Page - 1) * 2;
			var Products = _db.Products.Include(m => m.Company).Skip(NoOfSkiproducts).Take(2).ToList();
			var allProducts = new ShopViewModel()
			{
				products = Products,
				CurrentPage = (int)Page,
				NoOfPages = (int)Math.Ceiling(_db.Products.Count() / 2.0),
            };

            return View(allProducts);
		}
		public IActionResult Filter(int? Page,ShopFilterViewModel? data,int? min, int? max)
		{
			if (Page == null)
			{
				Page = 1;
			}
			int SkipNumberProduct = (int)(Page - 1) * 2;
			if(data != null)
			{
				data.MinPrice = (int)min;
				data.MaxPrice = (int)max;
			}
			var product = _db.Products.Include(m => m.Company).Where(m=>m.Price>=data.MinPrice && m.Price<=data.MaxPrice)
				.Skip(SkipNumberProduct).Take(2).ToList();
			var allProducts = new ShopFilterViewModel()
			{

				products = product,
				CurrentPage = (int)Page,
				MinPrice = data.MinPrice,
				MaxPrice = data.MaxPrice,
				TotalNumberOfPages = (int)Math.Ceiling(_db.Products.Where(m => m.Price >= data.MinPrice && m.Price <= data.MaxPrice).Count() / 2.0)
			};
			return View(allProducts);

			

		}
		public IActionResult Details(int id)
		{
			var product = _db.Products.Include(m=>m.Company).SingleOrDefault(m=>m.Id == id);

			return View(product);
		}

		public IActionResult Checkout() { return View(); }
	}
}
