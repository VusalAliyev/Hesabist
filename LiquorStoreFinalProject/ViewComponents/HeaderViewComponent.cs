using LiquorStoreFinalProject.Data;
using LiquorStoreFinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LiquorStoreFinalProject.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _accessor;
        public HeaderViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {

            string cookies = Request.Cookies["basket"];
            if (cookies != null)
            {
                List<BasketVM> basketProducts = JsonConvert.DeserializeObject<List<BasketVM>>(cookies);
                int totalCount = Convert.ToInt32(basketProducts.Sum(p=>p.Count));
                ViewBag.BasketCount=totalCount;
            }
            return View();

        }
    }
}
