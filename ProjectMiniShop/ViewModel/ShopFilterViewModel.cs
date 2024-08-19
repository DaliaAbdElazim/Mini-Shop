using ProjectMiniShop.Models;

namespace ProjectMiniShop.ViewModel
{
	public class ShopFilterViewModel
	{
		public List<Product> products { get; set; }
        public int TotalNumberOfPages { get; set; }
        public int CurrentPage { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
    }
}
