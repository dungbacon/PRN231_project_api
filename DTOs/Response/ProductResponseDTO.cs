namespace e_commerce_app_api.DTOs.Response
{
    public class ProductResponseDTO
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductImg { get; set; }
        public float Rating { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public int StockQuantity { get; set; }
        public string? Description { get; set; }
        public string? Data { get; set; }
    }
}
