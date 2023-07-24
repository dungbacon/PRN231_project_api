using e_commerce_app_api.DTOs.Response;
using System.ComponentModel.DataAnnotations;

namespace e_commerce_app_api.DTOs
{
    public class AccountDetailDTO
    {
        public int AccountId { get; set; }
        public string? FullName { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string? Password { get; set; }
        [Phone]
        public string? Phone { get; set; }
        public List<OrderResponseDTO> Orders { get; set; }
    }
}
