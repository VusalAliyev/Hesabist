using LiquorStoreFinalProject.Areas.Admin.ViewModels.Product;
using LiquorStoreFinalProject.ViewModels;

namespace LiquorStoreFinalProject.Services.Interfaces
{
    public interface IOrderService
    {
        void Create(OrderDetailsViewModel orderDetailsViewModel);
        Task DeleteAsync(int id);
    }
}
