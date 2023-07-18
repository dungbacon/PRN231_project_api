using e_commerce_app_api.DTOs.Request;
using e_commerce_app_api.DTOs.Response;

namespace e_commerce_app_api.Repositories
{
    public interface IOrderDetailRepository
    {
        Task<List<OrderDetailResponseDTO>> GetList();
        Task<List<OrderDetailResponseDTO>> GetListByOrder(int id);
        Task<OrderDetailResponseDTO> GetOrderDetailById(int id);
        Task<OrderDetailResponseDTO> AddOrderDetail(OrderDetailRequestDTO item);
        Task<OrderDetailResponseDTO> UpdateOrderDetail(OrderDetailRequestDTO item);
        Task DeleteOrderDetail(int id);

    }
}
