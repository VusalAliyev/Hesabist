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
    }
}
