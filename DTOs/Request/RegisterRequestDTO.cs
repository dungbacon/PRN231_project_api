using System.ComponentModel.DataAnnotations;

namespace e_commerce_app_api.DTOs.Request
{
    public class RegisterRequestDTO
    {
        public string? FullName { get; set; }
        [Phone]
        public string? PhoneNumber { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
