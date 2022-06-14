namespace RestaurantOrder.Api.Dtos
{
    public class OrderDetailsDTO
    {
        public string OrderDetailsId { get; set; } = string.Empty;        
        public string ItemName { get; set; } = string.Empty;        
        public string Price { get; set; } = string.Empty;        
        public string Quantity { get; set; } = string.Empty;        
        public string TableNumber { get; set; } = string.Empty;
    }
}
