using e_commerce_app_api.DTOs;
using e_commerce_app_api.DTOs.Request;
using e_commerce_app_api.DTOs.Response;

namespace e_commerce_app_api.Repositories
{
    public interface IOrderDetailRepository
    {
        Task<List<OrderDetailDTO>> GetList();
        Task<List<OrderDetailDTO>> GetListByOrder(int id);
        Task<List<MonthlyRevenuePerYearDTO>> GetTotalRevenueByMonthInAYear();
        Task<OrderDetailDTO> GetOrderDetailById(int id);
        Task<OrderDetailDTO> AddOrderDetail(OrderDetailRequestDTO item);
        Task<OrderDetailDTO> UpdateOrderDetail(OrderDetailDTO item);
        Task DeleteOrderDetail(int id);
        Task AddOrderDetails(List<OrderDetailRequestDTO> list);

    }
}
