using AutoMapper;
using e_commerce_app_api.DTOs.Request;
using e_commerce_app_api.DTOs.Response;
using e_commerce_app_api.Models;

namespace e_commerce_app_api.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderRequestDTO>().ReverseMap();
            CreateMap<Order, OrderDetailResponseDTO>().ReverseMap();
        }
    }
}
