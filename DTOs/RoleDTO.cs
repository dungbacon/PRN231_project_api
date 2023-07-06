namespace e_commerce_app_api.DTOs
{
    public class RoleDTO
    {
        public int RoleId { get; set; }
        public string RoleDesc { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
