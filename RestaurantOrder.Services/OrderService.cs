using RestaurantOrder.Models;
using RestaurantOrder.Repositories.Interfaces;

namespace RestaurantOrder.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        public OrderService(IOrderDetailRepository orderDetailRepository) 
        {      
            _orderDetailRepository = orderDetailRepository;
        }

        public OrderDetails AddNewOrder(OrderDetails newEntity)
        {
            return _orderDetailRepository.AddNewOrder(newEntity);
        }

        public bool DeleteOrder(string id)
        {
          return _orderDetailRepository.DeleteOrder(id);
        }

        public IEnumerable<OrderDetails> GetAllOrders()
        {
            return _orderDetailRepository.GetAllOrders();
        }

        public OrderDetails GetOrder(string id)
        {
            return _orderDetailRepository.GetOrderDetailsById(id);
        }

        public OrderDetails UpdateOrder(OrderDetails existingEntity)
        {
            return _orderDetailRepository.UpdateOrder(existingEntity);
        }            
    }
}
