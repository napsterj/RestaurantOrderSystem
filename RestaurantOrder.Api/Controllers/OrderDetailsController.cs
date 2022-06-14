using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantOrder.Api.Dtos;
using RestaurantOrder.Services;

namespace RestaurantOrder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderDetailsController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("orders")]
        public ActionResult GetOrders()
        {            
            return Ok(_orderService.GetAllOrders());
        }

        [HttpGet("single/order/{orderDetailsId}")]
        public ActionResult GetSpecificOrder([FromBody] string orderDetailsId)
        {
            var orderDetails = _orderService.GetOrder(orderDetailsId);
            if(orderDetails == null)
            {
                return BadRequest($"Order {orderDetailsId} not found");
            }
            return Ok(orderDetails);
        }

        [HttpPost("order/new")]
        public ActionResult PlaceNewOrder(OrderDetailsDTO orderDetailsDTO)
        {

        }
        
    }
}
