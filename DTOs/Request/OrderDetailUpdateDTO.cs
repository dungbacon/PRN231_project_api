namespace e_commerce_app_api.DTOs.Request
{
    public class OrderDetailUpdateDTO
    {
        public int OrderDetailId { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
