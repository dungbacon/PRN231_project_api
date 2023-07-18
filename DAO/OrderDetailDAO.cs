using e_commerce_app_api.Models;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_app_api.DAO
{
    public class OrderDetailDAO
    {
        private static OrderDetailDAO instance;

        private OrderDetailDAO() { }
        public static OrderDetailDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OrderDetailDAO();
                }
                return instance;
            }
        }

        public async Task<List<OrderDetail>?> GetList()
        {
            try
            {
                using (var ctx = new ECommerceAppDbContext())
                {
                    var list = await ctx.OrderDetails.Include(s => s.Product).ToListAsync();
                    return list;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<List<OrderDetail>?> GetListByOrder(int orderId)
        {
            try
            {
                using (var ctx = new ECommerceAppDbContext())
                {
                    var list = await ctx.OrderDetails.Where(s => s.OrderId == orderId).ToListAsync();
                    return list;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<OrderDetail?> GetOrderDetailById(int id)
        {
            try
            {
                using (var ctx = new ECommerceAppDbContext())
                {
                    var item = await ctx.OrderDetails.Where(s => s.OrderId == id).FirstOrDefaultAsync();
                    return item;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<OrderDetail?> AddOrderDetail(OrderDetail input)
        {
            try
            {
                using (var ctx = new ECommerceAppDbContext())
                {
                    input.CreateDate = DateTime.Now;
                    input.UpdatedDate = DateTime.Now;
                    ctx.OrderDetails.Add(input);
                    await ctx.SaveChangesAsync();
                    return await ctx.OrderDetails.Where(s => s.OrderDetailId == input.OrderDetailId).FirstOrDefaultAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<OrderDetail?> UpdateOrderDetail(OrderDetail input)
        {
            try
            {
                using (var ctx = new ECommerceAppDbContext())
                {
                    input.UpdatedDate = DateTime.Now;
                    ctx.Entry<OrderDetail>(input).State = EntityState.Modified;
                    await ctx.SaveChangesAsync();
                    return await ctx.OrderDetails.Where(s => s.OrderDetailId == input.OrderDetailId).FirstOrDefaultAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task DeleteOrderDetail(int orderDetailId)
        {
            try
            {
                using (var ctx = new ECommerceAppDbContext())
                {
                    var item = await ctx.OrderDetails.FirstOrDefaultAsync(s => s.OrderDetailId == orderDetailId);
                    ctx.OrderDetails.Remove(item);
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
