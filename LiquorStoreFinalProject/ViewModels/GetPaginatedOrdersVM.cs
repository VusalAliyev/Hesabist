using LiquorStoreFinalProject.Models;

namespace LiquorStoreFinalProject.ViewModels
{
    public class GetPaginatedOrdersVM
    {
        public List<Order> Orders { get; set; }
        public int CurrentPage { get; set; }
        public int Pages { get; set; }
    }
}
