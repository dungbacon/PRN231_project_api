using AutoMapper;
using e_commerce_app_api.DTOs;
using e_commerce_app_api.Models;

namespace e_commerce_app_api.Profiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleDTO>().ReverseMap();
        }
    }
}
