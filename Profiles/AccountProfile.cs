using AutoMapper;
using e_commerce_app_api.DTOs;
using e_commerce_app_api.Models;

namespace e_commerce_app_api.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountDTO>().ReverseMap();
        }
    }
}
