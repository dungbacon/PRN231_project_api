using System.ComponentModel.DataAnnotations;

namespace e_commerce_app_api.DTOs.Request
{
    public class LoginRequestDTO
    {
        [EmailAddress]
        [Required(ErrorMessage = "Email is required!")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password is required!")]
        public string? Password { get; set; }
    }
}
