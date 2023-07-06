using AutoMapper;
using e_commerce_app_api.DAO;
using e_commerce_app_api.DTOs;

namespace e_commerce_app_api.Repositories.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IMapper mapper;

        public RoleRepository(IMapper _mapper)
        {
            mapper = _mapper;
        }

        public async Task<RoleDTO> GetRoleById(int id) => mapper.Map<RoleDTO>(await RoleDAO.Instance.GetRoleById(id));
    }
}
