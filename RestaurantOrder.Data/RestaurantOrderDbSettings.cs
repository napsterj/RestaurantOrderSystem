using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrder.Data
{
    public class RestaurantOrderDbSettings : IRestaurantOrderDbSettings
    {
        public string OrderDetailsCollection { get; set; } = string.Empty;
        public string DbName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
    }
}
