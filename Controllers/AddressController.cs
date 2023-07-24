using e_commerce_app_api.DTOs.Request;
using e_commerce_app_api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce_app_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : Controller
    {
        private readonly IAddressRepository repo;
        private readonly IAccountRepository repoAccount;

        public AddressController(IAddressRepository _repo, IAccountRepository _repoAccount)
        {
            repo = _repo;
            repoAccount = _repoAccount;
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

        [HttpGet("{customerId}/list")]
        public async Task<IActionResult> GetListByCustomer(int customerId)
        {
            try
            {
                return Ok(await repo.GetListByCustomer(customerId));
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddressById(int id)
        {
            try
            {
                return Ok(await repo.GetAddressById(id));
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAddress(AddressRequestDTO item)
        {
            try
            {
                var response = await repo.AddAddress(item);

                return Ok(response);
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateAddress(AddressRequestDTO item, int id)
        {
            try
            {
                var accountEx = await repoAccount.GetAccountById(item.AccountId) != null;
                var addressEx = await repo.GetAddressById(id) != null;
                if (!addressEx)
                {
                    return NotFound("No address was found!");
                }
                var response = await repo.UpdateAddress(item);

                return Ok(response);
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            try
            {
                var orderDetailEx = await repo.GetAddressById(id);
                if (orderDetailEx == null)
                {
                    return NotFound("No cart was found!");
                }
                await repo.DeleteAddress(id);

                return Ok();
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }
    }
}
