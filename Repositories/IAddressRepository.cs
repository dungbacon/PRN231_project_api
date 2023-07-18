using e_commerce_app_api.DTOs.Request;
using e_commerce_app_api.DTOs.Response;

namespace e_commerce_app_api.Repositories
{
    public interface IAddressRepository
    {
        Task<List<AddressResponseDTO>> GetList();
        Task<List<AddressResponseDTO>> GetListByCustomer(int id);
        Task<AddressResponseDTO> GetAddressById(int id);
        Task<AddressResponseDTO> AddAddress(AddressRequestDTO input);
        Task<AddressResponseDTO> UpdateAddress(AddressRequestDTO input);
        Task DeleteAddress(int id);
    }
}
