using e_commerce_app_api.DTOs.Request;
using e_commerce_app_api.DTOs.Response;
using System.Runtime.InteropServices;

namespace e_commerce_app_api.Repositories
{
    public interface IProductRepository
    {
        Task<List<ProductResponseDTO>> GetList([Optional] int? pageNumber, [Optional] int? pageSize);
        Task<List<ProductResponseDTO>> GetItemsById(int cateId, int? pageNumber, int? pageSize);
        Task<ProductResponseDTO> GetItemById(int id);
        Task<ProductResponseDTO> AddItem(ProductRequestDTO item);
        Task<ProductResponseDTO> UpdateItem(ProductRequestDTO item, int id);
        Task DeleteItem(int id);
    }
}
