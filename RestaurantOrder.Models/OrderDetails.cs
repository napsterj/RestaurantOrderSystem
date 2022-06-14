using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RestaurantOrder.Models
{
    public class OrderDetails : BaseModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string OrderDetailsId { get; set; } = string.Empty;

        [BsonElement("itemName")]
        public string ItemName { get; set; } = string.Empty;

        [BsonElement("price")]
        public string Price { get; set; } = string.Empty;

        [BsonElement("quantity")]
        public string Quantity { get; set; } = string.Empty;

        [BsonElement("tableNumber")]
        public string TableNumber { get; set; } = string.Empty;
        
    }
}
