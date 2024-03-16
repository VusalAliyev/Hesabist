using LiquorStoreFinalProject.Services.Interfaces;
using LiquorStoreFinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LiquorStoreFinalProject.Controllers
{
    public class OrderController : Controller
    {
        readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public ActionResult CompleteOrder([FromBody]OrderViewModel model)
        {
            string randomCode = model.RandomCode;

            List<ProductList> products = model.Products;
            string content = "";
            int a = 1;
            foreach (var product in products)
            {
                content += a + ")" + "  " + product.Name + "  Qiymet --> " + product.Price + " AZN" + "  Miqdar --> " + product.Quantity + "\n";
                a++;
            }
            OrderDetailsViewModel orderDetailsViewModel = new OrderDetailsViewModel()
            {
                Code = randomCode,
                TotalPrice = model.TotalPrice,
                Content = content
            };
            _orderService.Create(orderDetailsViewModel);

            return Json(new { success = true });
        }
    }

  

  

  
}

