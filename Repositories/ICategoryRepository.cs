using e_commerce_app_api.DTOs.Request;
using e_commerce_app_api.DTOs.Response;

namespace e_commerce_app_api.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<CategoryResponseDTO>> GetList();
        Task<CategoryResponseDTO> AddItem(CategoryRequestDTO item);
        Task<CategoryResponseDTO> UpdateItem(CategoryRequestDTO item, int id);
        Task DeleteItem(int id);
    }
}
