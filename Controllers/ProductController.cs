using e_commerce_app_api.DTOs.Request;
using e_commerce_app_api.Models.Paging;
using e_commerce_app_api.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce_app_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductRepository repo;

        public ProductController(IProductRepository _repo)
        {
            repo = _repo;
        }

        [HttpGet("products")]
        [AllowAnonymous]
        public async Task<IActionResult> GetList([FromQuery] Pagination @params)
        {
            try
            {
                var total = repo.GetList(0, 0).Result.Count;
                var list = await repo.GetList(@params.Page, @params.PageSize);
                var listCount = list.Count;
                var response = new
                {
                    list,
                    listCount,
                    total
                };
                return Ok(response);
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpGet("{categoryId}/products")]
        public async Task<IActionResult> GetItemsById(int categoryId, [FromQuery] Pagination @params)
        {
            try
            {
                var list = await repo.GetItemsById(categoryId, @params.Page, @params.PageSize);
                var count = repo.GetItemsById(categoryId, 0, 0).Result.Count;
                var response = new
                {
                    list,
                    count
                };
                return Ok(response);
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpGet("products/{id}")]
        public async Task<IActionResult> GetItemById(int id)
        {
            try
            {
                return Ok(await repo.GetItemById(id));
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpPost("add")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> AddItem([FromBody] ProductRequestDTO req)
        {
            try
            {
                var item = await repo.AddItem(req);
                return Ok(item);
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpPut("update/{id}")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> UpdateItem([FromBody] ProductRequestDTO req, int id)
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
