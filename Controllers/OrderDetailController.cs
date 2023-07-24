using e_commerce_app_api.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce_app_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : Controller
    {
        private readonly IOrderDetailRepository repo;


        public OrderDetailController(IOrderDetailRepository _repo)
        {
            repo = _repo;
        }

        [HttpGet("months/revenue")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> GetTotalRevenueByMonthInAYear()
        {
            try
            {
                return Ok(await repo.GetTotalRevenueByMonthInAYear());
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }

    }
}
