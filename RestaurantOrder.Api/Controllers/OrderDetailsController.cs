using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantOrder.Api.Dtos;
using RestaurantOrder.Models;
using RestaurantOrder.Services;

namespace RestaurantOrder.Api.Controllers
{    
    [ApiController]
    [Route("[controller]")]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderDetailsController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet("orders")]
        public ActionResult GetOrders()
        {            
            return Ok(_orderService.GetAllOrders());
        }

        [HttpGet("single/order/{orderDetailsId}")]
        public ActionResult GetSpecificOrder(string orderDetailsId)
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
            OrderDetails orderDetails = _mapper.Map<OrderDetails>(orderDetailsDTO);
            
            if(orderDetails == null)
            {
                return NoContent();
            }
            return Ok(_orderService.AddNewOrder(orderDetails));
        }
        
    }
}
