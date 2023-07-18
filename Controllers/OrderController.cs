using e_commerce_app_api.DTOs.Request;
using e_commerce_app_api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce_app_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderDetailRepository repoOrderD;
        private readonly IOrderRepository repo;

        public OrderController(IOrderDetailRepository _repoOrderD, IOrderRepository _repo)
        {
            repo = _repo;
            repoOrderD = _repoOrderD;
        }
        [HttpGet("list")]
        public async Task<IActionResult> GetList()
        {
            try
            {
                return Ok(await repo.GetList());
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpGet("{customerId}/list")]
        public async Task<IActionResult> GetList(int customerId)
        {
            try
            {
                var list = await repo.GetListByCustomer(customerId);
                if (list == null || list.Count == 0)
                {
                    return NotFound("No order with customer was found!");
                }
                return Ok(list);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpGet("order/{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            try
            {
                var item = await repo.GetOrderById(id);
                if (item == null)
                {
                    return NotFound("No order was found!");
                }
                return Ok(item);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddOrder(OrderRequestDTO input)
        {
            try
            {
                var response = await repo.AddOrder(input);
                return Ok();
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }
    }
}
