using e_commerce_app_api.DTOs.Request;
using e_commerce_app_api.DTOs.Response;

namespace e_commerce_app_api.Repositories
{
    public interface IOrderRepository
    {
        Task<List<OrderResponseDTO>> GetListByCustomer(int id);
        Task<List<OrderResponseDTO>> GetList();
        Task<OrderResponseDTO> GetOrderById(int id);
        Task<OrderResponseDTO> AddOrder(OrderRequestDTO input);
        Task<OrderResponseDTO> UpdateOrder(OrderRequestDTO input);
        Task DeleteOrder(int id);
    }
}
