﻿namespace e_commerce_app_api.DTOs.Response
{
    public class CategoryResponseDTO
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryImg { get; set; }
        public bool IsActive { get; set; }
    }
}
