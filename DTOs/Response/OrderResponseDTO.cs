namespace e_commerce_app_api.DTOs.Response
{
    public class OrderResponseDTO
    {
        public int OrderId { get; set; }
        public int AccountId { get; set; }
        public int AddressId { get; set; }
        public int Status { get; set; }
        public decimal ShippingFee { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
