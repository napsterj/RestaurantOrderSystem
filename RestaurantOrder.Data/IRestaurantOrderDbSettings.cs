using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrder.Data
{
    public interface IRestaurantOrderDbSettings
    {
        string OrderDetailsCollection { get; set; }
        string DbName { get; set; }
        string ConnectionString { get; set; }
    }
}
