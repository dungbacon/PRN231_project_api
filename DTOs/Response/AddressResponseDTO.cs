namespace e_commerce_app_api.DTOs.Response
{
    public class AddressResponseDTO
    {
        public int AddressId { get; set; }
        public int AccountId { get; set; }
        public string? AddressDesc { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
