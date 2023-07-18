using e_commerce_app_api.DTOs.Request;
using e_commerce_app_api.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce_app_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository repo;

        public CategoryController(ICategoryRepository _repo)
        {
            repo = _repo;
        }

        [HttpGet("categories")]
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

        [HttpPost("add")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> AddItem([FromBody] CategoryRequestDTO req)
        {
            try
            {
                return Ok(await repo.AddItem(req));
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpPut("update/{id}")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> UpdateItem([FromBody] CategoryRequestDTO req, int id)
        {
            try
            {
                return Ok(await repo.UpdateItem(req, id));
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpPut("delete/{id}")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            try
            {
                await repo.DeleteItem(id);
                return Ok();
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }
    }
}
