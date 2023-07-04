using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_commerce_app_api.Models
{
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        public int AccountId { get; set; }
        public int AddressId { get; set; }
        public int StatusId { get; set; }
        public decimal ShippingFee { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public bool IsActive { get; set; }
        public virtual Account? Account { get; set; }
        public virtual Address? Address { get; set; }
        public virtual OrderStatus? OrderStatus { get; set; }
        public virtual List<OrderDetail>? OrderDetails { get; set; }
    }
}
