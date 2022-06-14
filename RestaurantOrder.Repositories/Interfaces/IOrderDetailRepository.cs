using RestaurantOrder.Models;
using RestaurantOrder.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrder.Repositories.Interfaces
{
    public interface IOrderDetailRepository
    {
        List<OrderDetails> GetAllOrders();
        OrderDetails GetOrderDetailsById(string id);
        OrderDetails AddNewOrder(OrderDetails orderDetails);
        OrderDetails UpdateOrder(OrderDetails orderDetails);
        bool DeleteOrder(string id);
    }
}
