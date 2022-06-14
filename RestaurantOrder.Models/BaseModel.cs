using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrder.Models
{
    public abstract class BaseModel
    {
        [BsonElement("createdDate")]
        public DateTime CreatedDate { get; set; }

        [BsonElement("createdBy")]
        public string CreatedBy { get; set; }
    }
}
