using e_commerce_app_api.DTOs.Response;
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
                    var list = await ctx.Orders.Include(s => s.OrderDetails).Where(s => s.AccountId == customerId && s.IsActive == true).ToListAsync();
                    return list;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<List<OrderResponseDTO>?> GetList()
        {
            try
            {
                using (var ctx = new ECommerceAppDbContext())
                {
                    var list = await ctx.Orders.Include(s => s.OrderDetails).Include(s => s.Address).Where(s => s.IsActive == true && s.IsActive == true).ToListAsync();
                    var response = list.Select(s => new OrderResponseDTO
                    {
                        OrderId = s.OrderId,
                        AccountId = s.AccountId,
                        Address = s.Address.AddressDesc,
                        OrderDate = s.OrderDate,
                        ShippedDate = s.ShippedDate,
                        ShippingFee = s.ShippingFee,
                        Status = s.Status == 0 ? "progressing" : "shipping",
                        TotalPrice = s.OrderDetails.Sum(s => s.TotalPrice),
                        IsActive = s.IsActive
                    }).ToList();
                    return response;
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
                    var item = await ctx.Orders.Include(s => s.OrderDetails).Where(s => s.OrderId == id && s.IsActive == true).FirstOrDefaultAsync();
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
                    return await ctx.Orders.Where(s => s.OrderId == input.OrderId && s.IsActive == true).FirstOrDefaultAsync();
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
                    return await ctx.Orders.Where(s => s.OrderId == input.OrderId && s.IsActive == true).FirstOrDefaultAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task UpdateOrderStatus(int id)
        {
            try
            {
                using (var ctx = new ECommerceAppDbContext())
                {
                    var item = await ctx.Orders.FirstOrDefaultAsync(s => s.OrderId == id);
                    if (item != null)
                    {
                        item.Status = 1;
                        ctx.Entry<Order>(item).State = EntityState.Modified;
                        await ctx.SaveChangesAsync();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public async Task DeleteOrder(int id)
        {
            try
            {
                using (var ctx = new ECommerceAppDbContext())
                {
                    var item = await ctx.Orders.FirstOrDefaultAsync(s => s.OrderId == id && s.IsActive == true);
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
