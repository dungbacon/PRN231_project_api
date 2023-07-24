using AutoMapper;
using e_commerce_app_api.DAO;
using e_commerce_app_api.DTOs;
using e_commerce_app_api.DTOs.Request;
using e_commerce_app_api.DTOs.Response;
using e_commerce_app_api.Models;

namespace e_commerce_app_api.Repositories.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly IMapper mapper;

        public OrderDetailRepository(IMapper _mapper)
        {
            mapper = _mapper;
        }

        public async Task<OrderDetailDTO> AddOrderDetail(OrderDetailRequestDTO item)
        {
            var a = mapper.Map<OrderDetail>(item);
            return mapper.Map<OrderDetailDTO>(await OrderDetailDAO.Instance.AddOrderDetail(a));
        }

        public Task AddOrderDetails(List<OrderDetailRequestDTO> list) => OrderDetailDAO.Instance.AddOrderDetails(mapper.Map<List<OrderDetail>>(list));

        public async Task DeleteOrderDetail(int id) => await OrderDetailDAO.Instance.DeleteOrderDetail(id);

        public async Task<List<OrderDetailDTO>> GetList() => mapper.Map<List<OrderDetailDTO>>(await OrderDetailDAO.Instance.GetList());

        public async Task<List<OrderDetailDTO>> GetListByOrder(int id) => mapper.Map<List<OrderDetailDTO>>(await OrderDetailDAO.Instance.GetListByOrder(id));

        public async Task<OrderDetailDTO> GetOrderDetailById(int id) => mapper.Map<OrderDetailDTO>(await OrderDetailDAO.Instance.GetOrderDetailById(id));

        public async Task<List<MonthlyRevenuePerYearDTO>?> GetTotalRevenueByMonthInAYear() => await OrderDetailDAO.Instance.GetTotalRevenueByMonthInAYear();

        public async Task<OrderDetailDTO> UpdateOrderDetail(OrderDetailDTO item)
        {
            var a = mapper.Map<OrderDetail>(item);
            return mapper.Map<OrderDetailDTO>(await OrderDetailDAO.Instance.UpdateOrderDetail(a));
        }
    }
}
