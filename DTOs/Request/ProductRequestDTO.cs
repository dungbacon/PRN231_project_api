using System.ComponentModel.DataAnnotations;

namespace e_commerce_app_api.DTOs.Request
{
    public class ProductRequestDTO
    {
        public int CategoryId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductImg { get; set; }
        [Range(1, 5)]
        public float Rating { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public int StockQuantity { get; set; }
        public string? Description { get; set; }
        public string? Data { get; set; }
    }
}
