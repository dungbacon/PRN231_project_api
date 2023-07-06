using e_commerce_app_api.DTOs;

namespace e_commerce_app_api.Repositories
{
    public interface IRoleRepository
    {
        Task<RoleDTO> GetRoleById(int id);
    }
}
