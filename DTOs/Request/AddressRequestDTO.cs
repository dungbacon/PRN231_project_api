namespace e_commerce_app_api.DTOs.Request
{
    public class AddressRequestDTO
    {
        public int AccountId { get; set; }
        public string? AddressDesc { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
