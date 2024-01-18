using VerstaTestTask.DAL;
using VerstaTestTask.Domain;
using VerstaTestTask.Domain.Models;

namespace VerstaTestTask.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<IBaseResponse<Order>> GetOrder(int id)
        {
            var baseResponse = new BaseResponse<Order>();
            try
            {
                var order = await _orderRepository.GetOrderById(id);
                if(order==null)
                {
                    baseResponse.StatusCode = 404;
                    baseResponse.Description = "Order not found";
                    return baseResponse;
                }

                baseResponse.Data = order;
                baseResponse.StatusCode = 200;
                return baseResponse;
            }
            catch (Exception ex)
            {
                baseResponse.StatusCode = 500;
                baseResponse.Description = ex.Message;
                
            }
            return baseResponse;
        }

        public async Task<IBaseResponse<IEnumerable<Order>>> GetOrders()
        {
            var baseResponse = new BaseResponse<IEnumerable<Order>>();
            try
            {
                var orders = await _orderRepository.GetAllOrders();
                baseResponse.Data = orders;
                baseResponse.StatusCode = 200;

                return baseResponse;
            }
            catch (Exception ex)
            {
                baseResponse.StatusCode = 500;
                baseResponse.Description = ex.Message;

            }
            return baseResponse;
        }

        public async Task<IBaseResponse<bool>> CreateOrder(Order order)
        {
            var baseResponse = new BaseResponse<bool>();

                try
                {
                    order.Number = Guid.NewGuid();
                    await _orderRepository.CreateOrder(order);
                    baseResponse.Data = true;
                    baseResponse.StatusCode = 201;

                    return baseResponse;
                }
                catch (Exception ex)
                {
                    baseResponse.StatusCode = 500;
                    baseResponse.Description = ex.Message;
                    baseResponse.Data = false;
                }
                return baseResponse;
            }

    }
}
