using LiquorStoreFinalProject.Controllers;
using LiquorStoreFinalProject.Data;
using LiquorStoreFinalProject.Models;
using LiquorStoreFinalProject.Services.Interfaces;
using LiquorStoreFinalProject.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace LiquorStoreFinalProject.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;

        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        public void Create(OrderDetailsViewModel orderDetailsViewModel)
        {
            var order = new Order()
            {
                Code = orderDetailsViewModel.Code,
                Content = orderDetailsViewModel.Content,
                TotalPrice = orderDetailsViewModel.TotalPrice
            };
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {

            var deletedOrder = await _context.Orders.FirstOrDefaultAsync(p => p.Id == id);
            _context.Orders.Remove(deletedOrder);

            _context.SaveChanges();
        }


        public async Task<GetPaginatedOrdersVM> GetOrdersAsync(int page, string searchTerm = null)
        {
            var pageResults = 6f;

            IQueryable<Order> ordersQuery = _context.Orders;
            if (!string.IsNullOrEmpty(searchTerm))
            {
                ordersQuery = ordersQuery.Where(o => o.Content.Contains(searchTerm));
            }

            var pageCount = Math.Ceiling(ordersQuery.Count() / pageResults);

            var orders = await ordersQuery
                .Select(p => new Order
                {
                    Code = p.Code,
                    Content = p.Content,
                    TotalPrice = p.TotalPrice,
                    CreatedDate = p.CreatedDate
                })
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults)
                .ToListAsync();

            return new GetPaginatedOrdersVM
            {
                CurrentPage = page,
                Orders = orders,
                Pages = (int)pageCount
            };
        }
    }
}
