using e_commerce_app_api.Models;
using System.ComponentModel.DataAnnotations;

namespace e_commerce_app_api.DTOs
{
    public class AccountDTO
    {
        public int AccountId { get; set; }
        public int RoleId { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? FullName { get; set; }
        [Phone]
        public string? Phone { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public Role? Role { get; set; }

    }
}
