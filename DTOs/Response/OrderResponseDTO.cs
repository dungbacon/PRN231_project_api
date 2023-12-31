﻿namespace e_commerce_app_api.DTOs.Response
{
    public class OrderResponseDTO
    {
        public int OrderId { get; set; }
        public int AccountId { get; set; }
        public string? Address { get; set; }
        public string Status { get; set; }
        public decimal ShippingFee { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public int TotalPrice { get; set; }
        public bool IsActive { get; set; }

    }
}
