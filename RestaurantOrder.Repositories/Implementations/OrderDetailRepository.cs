using MongoDB.Driver;
using RestaurantOrder.Data;
using RestaurantOrder.Models;
using RestaurantOrder.Repositories.Interfaces;

namespace RestaurantOrder.Repositories.Implementations
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly IRestaurantOrderDbSettings _restaurantOrderDbSettings;
        private readonly IMongoCollection<OrderDetails> orderDetailsCollection;
        public OrderDetailRepository(IRestaurantOrderDbSettings restaurantOrderDbSettings, 
                                     IMongoClient mongoClient)        
        {
            _restaurantOrderDbSettings = restaurantOrderDbSettings;
            var database = mongoClient.GetDatabase(_restaurantOrderDbSettings.DbName);
            orderDetailsCollection = database.GetCollection<OrderDetails>(_restaurantOrderDbSettings.OrderDetailsCollection);
        }

        public OrderDetails AddNewOrder(OrderDetails orderDetails)
        {
            orderDetailsCollection.InsertOne(orderDetails);
            return orderDetails;
        }

        public bool DeleteOrder(string id)
        {
            var orderToDelete = orderDetailsCollection.Find(id);
            if(orderToDelete == null)
            {
                return false;
            }
            var result = orderDetailsCollection.DeleteOne(id);
            return result.DeletedCount > 0;
        }

        public List<OrderDetails> GetAllOrders()
        {
            return orderDetailsCollection.Find(_ => true).ToList();
        }

        public OrderDetails GetOrderDetailsById(string id)
        {
             return orderDetailsCollection.Find(id).FirstOrDefault();
        }

        public OrderDetails? UpdateOrder(OrderDetails orderDetails)
        {
           var orderToUpdate = orderDetailsCollection.Find(orderDetails.OrderDetailsId.ToString()).FirstOrDefault();
           if(orderToUpdate == null)
           {
                return null;
           }
           orderDetailsCollection.ReplaceOne(orderToUpdate.OrderDetailsId.ToString(), orderDetails);
           return orderDetails;
        }
    }
}
