using VerstaTestTask.Domain.Models;

namespace VerstaTestTask.DAL
{
    public interface IOrderRepository
    {
        public Task<Order> GetOrderById(int id);

        public Task<IEnumerable<Order>> GetAllOrders();

        public Task CreateOrder(Order order);
    }
}
