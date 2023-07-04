using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_commerce_app_api.Models
{
    public class Account
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountId { get; set; }
        public int RoleId { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? FullName { get; set; }
        public string? Phone { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public virtual Role? Role { get; set; }
        public virtual List<Order>? Orders { get; set; }
        public virtual List<Address>? Addresses { get; set; }
    }
}
