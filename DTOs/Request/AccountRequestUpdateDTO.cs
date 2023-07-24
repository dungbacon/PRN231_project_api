using System.ComponentModel.DataAnnotations;

namespace e_commerce_app_api.DTOs.Request
{
    public class AccountRequestUpdateDTO
    {
        public string? FullName { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string? Password { get; set; }
        [Phone]
        public string? Phone { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
