using AutoMapper;
using e_commerce_app_api.DAO;
using e_commerce_app_api.DTOs.Request;
using e_commerce_app_api.DTOs.Response;
using e_commerce_app_api.Models;

namespace e_commerce_app_api.Repositories.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IMapper mapper;

        public CategoryRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async Task<CategoryResponseDTO> AddItem(CategoryRequestDTO item)
        {
            var cate = mapper.Map<Category>(item);
            return mapper.Map<CategoryResponseDTO>(await CategoryDAO.Instance.AddItem(cate));
        }

        public Task DeleteItem(int id) => CategoryDAO.Instance.DeleteItem(id);

        public async Task<List<CategoryResponseDTO>> GetList() => mapper.Map<List<CategoryResponseDTO>>(await CategoryDAO.Instance.GetList());

        public async Task<CategoryResponseDTO> UpdateItem(CategoryRequestDTO item, int id)
        {
            var cate = mapper.Map<Category>(item);
            return mapper.Map<CategoryResponseDTO>(await CategoryDAO.Instance.UpdateItem(cate, id));
        }
    }
}
