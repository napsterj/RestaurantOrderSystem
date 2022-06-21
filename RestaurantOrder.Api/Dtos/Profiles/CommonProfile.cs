using AutoMapper;
using RestaurantOrder.Models;

namespace RestaurantOrder.Api.Dtos.Profiles
{
    public class CommonProfile : Profile
    {
        public CommonProfile()
        {
            CreateMap<OrderDetailsDTO, OrderDetails>().ReverseMap();
        }
    }
}
