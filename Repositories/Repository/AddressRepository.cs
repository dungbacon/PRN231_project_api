using AutoMapper;
using e_commerce_app_api.DAO;
using e_commerce_app_api.DTOs.Request;
using e_commerce_app_api.DTOs.Response;
using e_commerce_app_api.Models;

namespace e_commerce_app_api.Repositories.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly IMapper mapper;

        public AddressRepository(IMapper _mapper)
        {
            mapper = _mapper;
        }
        public async Task<AddressResponseDTO> AddAddress(AddressRequestDTO input)
        {
            var a = mapper.Map<Address>(input);
            return mapper.Map<AddressResponseDTO>(await AddressDAO.Instance.AddAddress(a));
        }

        public Task DeleteAddress(int id) => AddressDAO.Instance.DeleteAddress(id);

        public async Task<AddressResponseDTO> GetAddressById(int id) => mapper.Map<AddressResponseDTO>(await AddressDAO.Instance.GetAddressById(id));

        public async Task<List<AddressResponseDTO>> GetList() => mapper.Map<List<AddressResponseDTO>>(await AddressDAO.Instance.GetList());

        public async Task<List<AddressResponseDTO>> GetListByCustomer(int id) => mapper.Map<List<AddressResponseDTO>>(await AddressDAO.Instance.GetListByCustomer(id));

        public async Task<AddressResponseDTO> UpdateAddress(AddressRequestDTO input)
        {
            var a = mapper.Map<Address>(input);
            return mapper.Map<AddressResponseDTO>(await AddressDAO.Instance.UpdateAddress(a));
        }
    }
}
