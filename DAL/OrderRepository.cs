using Microsoft.EntityFrameworkCore;
using VerstaTestTask.Domain.Models;

namespace VerstaTestTask.DAL
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        public OrderRepository(ApplicationDbContext context)
        {
            _context = context; 
        }
        public async Task CreateOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await _context.Orders.FirstOrDefaultAsync(order=>order.Id==id);
            //return await _context.Orders.FindAsync(id);
        }
    }
}
