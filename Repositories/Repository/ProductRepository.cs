using AutoMapper;
using e_commerce_app_api.DAO;
using e_commerce_app_api.DTOs.Request;
using e_commerce_app_api.DTOs.Response;
using e_commerce_app_api.Models;
using System.Runtime.InteropServices;

namespace e_commerce_app_api.Repositories.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMapper mapper;

        public ProductRepository(IMapper _mapper) { mapper = _mapper; }

        public async Task<ProductResponseDTO> AddItem(ProductRequestDTO item)
        {
            return mapper.Map<ProductResponseDTO>(await ProductDAO.Instance.AddItem(mapper.Map<Product>(item)));
        }

        public async Task DeleteItem(int id) => await ProductDAO.Instance.DeleteItem(id);

        public async Task<ProductResponseDTO> GetItemById(int id) => mapper.Map<ProductResponseDTO>(await ProductDAO.Instance.GetItemById(id));

        public async Task<List<ProductResponseDTO>> GetItemsById(int cateId, int? pageNumber, int? pageSize) => mapper.Map<List<ProductResponseDTO>>(await ProductDAO.Instance.GetItemsById(cateId, pageNumber, pageSize));

        public async Task<List<ProductResponseDTO>> GetList([Optional] int? pageNumber, [Optional] int? pageSize) => mapper.Map<List<ProductResponseDTO>>(await ProductDAO.Instance.GetList(pageNumber, pageSize));

        public async Task<ProductResponseDTO> UpdateItem(ProductRequestDTO item, int id)
        {
            return mapper.Map<ProductResponseDTO>(await ProductDAO.Instance.UpdateItem(mapper.Map<Product>(item), id));

        }
    }
}
