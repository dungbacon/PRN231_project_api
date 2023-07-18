using e_commerce_app_api.DTOs.Request;
using e_commerce_app_api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce_app_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : Controller
    {
        private readonly IOrderDetailRepository repo;
        private readonly IOrderRepository repoOrder;

        public OrderDetailController(IOrderDetailRepository _repo, IOrderRepository _repoOrder)
        {
            repo = _repo;
            repoOrder = _repoOrder;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetList()
        {
            try
            {
                return Ok(await repo.GetList());
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpGet("{orderId}/list")]
        public async Task<IActionResult> GetListByOrder(int orderId)
        {
            try
            {
                return Ok(await repo.GetListByOrder(orderId));
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddOrderDetail(OrderDetailRequestDTO item)
        {
            try
            {
                var orderEx = repoOrder.GetOrderById(item.OrderId) != null ? true : false;
                if (!orderEx)
                {
                    return NotFound("No order was found!");
                }
                var response = await repo.AddOrderDetail(item);

                return Ok(response);
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateOrderDetail(OrderDetailRequestDTO item, int id)
        {
            try
            {
                var orderEx = await repoOrder.GetOrderById(item.OrderId) != null;
                var orderDetailEx = await repo.GetOrderDetailById(id) != null;
                if (!orderEx || !orderDetailEx)
                {
                    return NotFound("No order nor cart was found!");
                }
                var response = await repo.AddOrderDetail(item);

                return Ok(response);
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpPut("delete/{id}")]
        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
            try
            {
                var orderDetailEx = repo.GetOrderDetailById(id) != null ? true : false;
                if (!orderDetailEx)
                {
                    return NotFound("No cart was found!");
                }
                await repo.DeleteOrderDetail(id);

                return Ok();
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }
    }
}
