using AutoMapper;
using e_commerce_app_api.DAO;
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

        public async Task<OrderDetailResponseDTO> AddOrderDetail(OrderDetailRequestDTO item)
        {
            var a = mapper.Map<OrderDetail>(item);
            return mapper.Map<OrderDetailResponseDTO>(await OrderDetailDAO.Instance.AddOrderDetail(a));
        }

        public async Task DeleteOrderDetail(int id) => await OrderDetailDAO.Instance.DeleteOrderDetail(id);

        public async Task<List<OrderDetailResponseDTO>> GetList() => mapper.Map<List<OrderDetailResponseDTO>>(await OrderDetailDAO.Instance.GetList());

        public async Task<List<OrderDetailResponseDTO>> GetListByOrder(int id) => mapper.Map<List<OrderDetailResponseDTO>>(await OrderDetailDAO.Instance.GetListByOrder(id));

        public async Task<OrderDetailResponseDTO> GetOrderDetailById(int id) => mapper.Map<OrderDetailResponseDTO>(await OrderDetailDAO.Instance.GetOrderDetailById(id));

        public async Task<OrderDetailResponseDTO> UpdateOrderDetail(OrderDetailRequestDTO item)
        {
            var a = mapper.Map<OrderDetail>(item);
            return mapper.Map<OrderDetailResponseDTO>(await OrderDetailDAO.Instance.UpdateOrderDetail(a));
        }
    }
}
