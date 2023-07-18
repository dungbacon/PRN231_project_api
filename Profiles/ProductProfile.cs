using AutoMapper;
using e_commerce_app_api.DTOs.Request;
using e_commerce_app_api.DTOs.Response;
using e_commerce_app_api.Models;

namespace e_commerce_app_api.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductResponseDTO>().ReverseMap();
            CreateMap<ProductRequestDTO, Product>().ReverseMap();
        }
    }
}
