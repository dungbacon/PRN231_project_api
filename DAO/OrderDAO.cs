using e_commerce_app_api.Models;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_app_api.DAO
{
    public class OrderDAO
    {
        private static OrderDAO instance;

        private OrderDAO() { }
        public static OrderDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OrderDAO();
                }
                return instance;
            }
        }

        public async Task<List<Order>?> GetListByCustomer(int customerId)
        {
            try
            {
                using (var ctx = new ECommerceAppDbContext())
                {
                    var list = await ctx.Orders.Where(s => s.AccountId == customerId).ToListAsync();
                    return list;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<List<Order>?> GetList()
        {
            try
            {
                using (var ctx = new ECommerceAppDbContext())
                {
                    var list = await ctx.Orders.ToListAsync();
                    return list;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<Order?> GetOrderById(int id)
        {
            try
            {
                using (var ctx = new ECommerceAppDbContext())
                {
                    var item = await ctx.Orders.FirstOrDefaultAsync(s => s.OrderId == id);
                    return item;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<Order?> AddOrder(Order input)
        {
            try
            {
                using (var ctx = new ECommerceAppDbContext())
                {
                    ctx.Orders.Add(input);
                    await ctx.SaveChangesAsync();
                    return await ctx.Orders.Where(s => s.OrderId == input.OrderId).FirstOrDefaultAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<Order?> UpdateOrder(Order input)
        {
            try
            {
                using (var ctx = new ECommerceAppDbContext())
                {
                    ctx.Entry<Order>(input).State = EntityState.Modified;
                    await ctx.SaveChangesAsync();
                    return await ctx.Orders.Where(s => s.OrderId == input.OrderId).FirstOrDefaultAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task DeleteOrder(int id)
        {
            try
            {
                using (var ctx = new ECommerceAppDbContext())
                {
                    var item = await ctx.Orders.FirstOrDefaultAsync(s => s.OrderId == id);
                    ctx.Orders.Remove(item!);
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
