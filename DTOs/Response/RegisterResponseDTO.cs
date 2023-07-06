namespace e_commerce_app_api.DTOs.Response
{
    public class RegisterResponseDTO
    {
        public AccountDTO Account { get; set; }
        public string AccessToken { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ExpiredDate { get; set; }
    }
}
