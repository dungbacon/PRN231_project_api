using e_commerce_app_api.DTOs;
using e_commerce_app_api.DTOs.Response;

namespace e_commerce_app_api.Repositories
{
    public interface IOrderRepository
    {
        Task<List<OrderResponseDTO>> GetListByCustomer(int id);
        Task<List<OrderResponseDTO>> GetList();
        Task<OrderFulDTO> GetOrderById(int id);
        Task<OrderFulDTO> AddOrder(OrderDTO input);
        Task<OrderFulDTO> UpdateOrder(OrderDTO input);
        Task DeleteOrder(int id);
        Task UpdateOrderStatus(int id);
    }
}
