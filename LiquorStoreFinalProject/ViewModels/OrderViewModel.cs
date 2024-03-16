using LiquorStoreFinalProject.Controllers;

namespace LiquorStoreFinalProject.ViewModels
{
    public class OrderViewModel
    {
        public string RandomCode { get; set; }
        public List<ProductList> Products { get; set; }
        public string TotalPrice { get; set; }

    }
    public class ProductList
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
