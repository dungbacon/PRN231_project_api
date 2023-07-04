using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_commerce_app_api.Models
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        public DateTime CreateDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public virtual Category? Category { get; set; }
    }
}
