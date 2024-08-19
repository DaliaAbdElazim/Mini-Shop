using ProjectMiniShop.Models;

namespace ProjectMiniShop.ViewModel
{
    public class ShopViewModel
    {
        public List<Product> products { get; set; }
        public int CurrentPage { get; set; }

        public int NoOfPages { get; set; }
    }
}
