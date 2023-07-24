using e_commerce_app_api.DTOs.Request;
using e_commerce_app_api.Models;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_app_api.DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;

        private CategoryDAO() { }
        public static CategoryDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CategoryDAO();
                }
                return instance;
            }
        }

        public async Task<List<Category>> GetList()
        {
            var list = new List<Category>();
            try
            {
                using (var ctx = new ECommerceAppDbContext())
                {
                    list = await ctx.Categories.Where(s => s.IsActive == true).ToListAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return list;
        }

        public async Task<Category?> AddItem(Category item)
        {
            try
            {
                using (var ctx = new ECommerceAppDbContext())
                {
                    ctx.Categories.Add(item);
                    await ctx.SaveChangesAsync();
                    return await ctx.Categories.Where(s => s.CategoryId == item.CategoryId && s.IsActive == true).FirstOrDefaultAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;

            }
        }

        public async Task<Category?> UpdateItem(CategoryUpdateRequestDTO input, int id)
        {
            try
            {
                using (var ctx = new ECommerceAppDbContext())
                {
                    var item = await ctx.Categories.FirstOrDefaultAsync(s => s.CategoryId == id && s.IsActive == true);
                    if (item != null)
                    {
                        item.CategoryName = input.CategoryName;
                        item.CategoryImg = input.CategoryImg;
                        item.UpdatedDate = DateTime.Now;
                    }
                    ctx.Entry<Category>(item!).State = EntityState.Modified;
                    await ctx.SaveChangesAsync();
                    return item;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task DeleteItem(int id)
        {
            var item = new Category();
            try
            {
                using (var ctx = new ECommerceAppDbContext())
                {
                    item = await ctx.Categories.Where(s => s.CategoryId == id).FirstOrDefaultAsync();
                    if (item != null)
                    {
                        item.IsActive = false;

                    }
                    await ctx.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
