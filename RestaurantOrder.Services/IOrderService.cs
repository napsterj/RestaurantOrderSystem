using RestaurantOrder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrder.Services
{
    public interface IOrderService
    {
        IEnumerable<OrderDetails> GetAllOrders();
        OrderDetails GetOrder(string id);
        OrderDetails AddNewOrder(OrderDetails newEntity);
        OrderDetails UpdateOrder(OrderDetails existingEntity);
        bool DeleteOrder(string id);        
    }
}
