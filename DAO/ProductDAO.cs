using e_commerce_app_api.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace e_commerce_app_api.DAO
{
    public class ProductDAO
    {
        private static ProductDAO instance;

        private ProductDAO() { }
        public static ProductDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProductDAO();
                }
                return instance;
            }
        }


        public async Task<List<Product>?> GetList([Optional] int? pageNumber, [Optional] int? pageSize)
        {
            try
            {
                using (var ctx = new ECommerceAppDbContext())
                {
                    var list = ctx.Products.Where(s => s.IsActive == true);
                    if (pageNumber != 0 && pageSize != 0)
                    {
                        int itemsToSkip = (pageNumber - 1) * pageSize ?? 0;
                        list = list.Skip(itemsToSkip).Take(pageSize ?? 0);
                    }
                    return await list.ToListAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<List<Product>> GetItemsById(int cateid, int? pageNumber, int? pageSize)
        {
            try
            {
                using (var ctx = new ECommerceAppDbContext())
                {
                    var list = ctx.Products.Where(s => s.CategoryId == cateid && s.IsActive == true);
                    if (pageNumber != 0 && pageSize != 0)
                    {
                        int itemsToSkip = (pageNumber - 1) * pageSize ?? 0;
                        list = list.Skip(itemsToSkip).Take(pageSize ?? 0);
                    }
                    return await list.ToListAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<Product> GetItemById(int id)
        {
            var item = new Product();
            try
            {
                using (var ctx = new ECommerceAppDbContext())
                {
                    item = await ctx.Products.Where(s => s.ProductId == id && s.IsActive == true).FirstOrDefaultAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return item;
        }

        public async Task<Product?> AddItem(Product item)
        {
            try
            {
                using (var ctx = new ECommerceAppDbContext())
                {
                    item.CreateDate = DateTime.Now;
                    item.UpdatedDate = DateTime.Now;
                    item.IsActive = true;
                    ctx.Products.Add(item);
                    await ctx.SaveChangesAsync();
                    return await ctx.Products.Where(s => s.ProductId == item.ProductId && s.IsActive == true).FirstOrDefaultAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<Product> UpdateItem(Product item, int id)
        {
            try
            {
                using (var ctx = new ECommerceAppDbContext())
                {
                    item.UpdatedDate = DateTime.Now;
                    ctx.Entry<Product>(item).State = EntityState.Modified;
                    await ctx.SaveChangesAsync();
                    return await ctx.Products.Where(s => s.ProductId == item.ProductId && s.IsActive == true).FirstOrDefaultAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public async Task DeleteItem(int id)
        {
            var item = new Product();
            try
            {
                using (var ctx = new ECommerceAppDbContext())
                {
                    item = await ctx.Products.Where(s => s.ProductId == id).FirstOrDefaultAsync();
                    item.IsActive = false;
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
