namespace e_commerce_app_api.DTOs.Request
{
    public class OrderRequestDTO
    {
        public OrderDTO Order { get; set; }
        public List<OrderDetailRequestDTO>? OrderDetails { get; set; }
    }
}
