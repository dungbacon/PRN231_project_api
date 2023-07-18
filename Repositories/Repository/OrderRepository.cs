using AutoMapper;
using e_commerce_app_api.DAO;
using e_commerce_app_api.DTOs.Request;
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

        public async Task<OrderResponseDTO> AddOrder(OrderRequestDTO input)
        {
            var a = mapper.Map<Order>(input);
            return mapper.Map<OrderResponseDTO>(await OrderDAO.Instance.AddOrder(a));

        }

        public async Task DeleteOrder(int id) => await OrderDAO.Instance.DeleteOrder(id);

        public async Task<List<OrderResponseDTO>> GetList() => mapper.Map<List<OrderResponseDTO>>(await OrderDAO.Instance.GetList());

        public async Task<List<OrderResponseDTO>> GetListByCustomer(int id) => mapper.Map<List<OrderResponseDTO>>(await OrderDAO.Instance.GetListByCustomer(id));

        public async Task<OrderResponseDTO> GetOrderById(int id) => mapper.Map<OrderResponseDTO>(await OrderDAO.Instance.GetOrderById(id));

        public async Task<OrderResponseDTO> UpdateOrder(OrderRequestDTO input)
        {
            var a = mapper.Map<Order>(input);
            return mapper.Map<OrderResponseDTO>(await OrderDAO.Instance.UpdateOrder(a));
        }
    }
}
