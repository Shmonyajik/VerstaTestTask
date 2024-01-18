using VerstaTestTask.Domain;
using VerstaTestTask.Domain.Models;

namespace VerstaTestTask.Services
{
    public interface IOrderService
    {

        public Task<IBaseResponse<IEnumerable<Order>>> GetOrders();
        public Task<IBaseResponse<Order>> GetOrder(int id);
        public Task<IBaseResponse<bool>> CreateOrder(Order order);

    }
}
