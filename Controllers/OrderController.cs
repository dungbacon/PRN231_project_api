using e_commerce_app_api.DTOs;
using e_commerce_app_api.DTOs.Request;
using e_commerce_app_api.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce_app_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderRepository repo;
        private readonly IAddressRepository repoAddress;
        private readonly IAccountRepository repoAccount;
        private readonly IOrderDetailRepository repoOrderDetail;

        public OrderController(IOrderRepository _repo, IAddressRepository _repoAddress, IAccountRepository _repoAccount, IOrderDetailRepository _repoOrderDetail)
        {
            repo = _repo;
            repoAddress = _repoAddress;
            repoAccount = _repoAccount;
            repoOrderDetail = _repoOrderDetail;
        }

        [HttpGet("list")]
        [Authorize(Policy = "AdminOnly")]
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


        [HttpPost("add")]
        public async Task<IActionResult> AddOrder(OrderDTO input)
        {
            try
            {
                var addOrderTask = repo.AddOrder(input);
                return Ok();
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }


        [HttpPost("addOrder")]
        [Authorize]
        public async Task<IActionResult> AddOrder([FromBody] OrderRequestDTO request)
        {
            try
            {
                var item = await repo.AddOrder(request.Order);
                if (item != null)
                {
                    foreach (var od in request.OrderDetails)
                    {
                        od.OrderId = item.OrderId;
                    }
                    await repoOrderDetail.AddOrderDetails(request.OrderDetails);
                }
                else
                {
                    return Conflict();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpPut("order/{id}/status")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> UpdateOrder(int id)
        {
            try
            {
                var orderEx = await repo.GetOrderById(id) != null;
                if (!orderEx)
                {
                    return NotFound("Account nor Address were not valid!");
                }
                await repo.UpdateOrderStatus(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            try
            {
                var orderEx = await repo.GetOrderById(id) != null;
                if (!orderEx)
                {
                    return NotFound("No Order was found!");
                }
                await repo.DeleteOrder(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }
    }
}
