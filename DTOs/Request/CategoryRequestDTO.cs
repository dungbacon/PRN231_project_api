﻿namespace e_commerce_app_api.DTOs.Request
{
    public class CategoryRequestDTO
    {
        public string? CategoryName { get; set; }
        public string? CategoryImg { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }
    }
}
