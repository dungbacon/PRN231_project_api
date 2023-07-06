using e_commerce_app_api.Models;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_app_api.DAO
{
    public class RoleDAO
    {
        private static RoleDAO instance;

        private RoleDAO() { }
        public static RoleDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RoleDAO();
                }
                return instance;
            }
        }

        public async Task<Role> GetRoleById(int id)
        {
            var item = new Role();
            try
            {
                using (var ctx = new ECommerceAppDbContext())
                {
                    item = await ctx.Roles.Where(s => s.RoleId == id && s.IsActive == true).FirstOrDefaultAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return item;
        }
    }
}
