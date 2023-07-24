using AutoMapper;
using e_commerce_app_api.DAO;
using e_commerce_app_api.DTOs;
using e_commerce_app_api.DTOs.Response;
using e_commerce_app_api.Models;

namespace e_commerce_app_api.Repositories.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IMapper mapper;

        public OrderRepository(IMapper _mapper)
        {
            mapper = _mapper;
        }

        public async Task<OrderFulDTO> AddOrder(OrderDTO input)
        {
            var a = mapper.Map<Order>(input);
            return mapper.Map<OrderFulDTO>(await OrderDAO.Instance.AddOrder(a));
        }
        public async Task DeleteOrder(int id) => await OrderDAO.Instance.DeleteOrder(id);
        public async Task<List<OrderResponseDTO>?> GetList() => await OrderDAO.Instance.GetList();
        public async Task<List<OrderResponseDTO>> GetListByCustomer(int id) => mapper.Map<List<OrderResponseDTO>>(await OrderDAO.Instance.GetListByCustomer(id));
        public async Task<OrderFulDTO> GetOrderById(int id) => mapper.Map<OrderFulDTO>(await OrderDAO.Instance.GetOrderById(id));
        public async Task<OrderFulDTO> UpdateOrder(OrderDTO input)
        {
            var a = mapper.Map<Order>(input);
            return mapper.Map<OrderFulDTO>(await OrderDAO.Instance.UpdateOrder(a));
        }
        public async Task UpdateOrderStatus(int id) => await OrderDAO.Instance.UpdateOrderStatus(id);
    }
}
