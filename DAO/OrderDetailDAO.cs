using e_commerce_app_api.DTOs.Response;
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

        public async Task<List<MonthlyRevenuePerYearDTO>?> GetTotalRevenueByMonthInAYear()
        {
            try
            {
                DateTime startDate = new DateTime(2023, 1, 1);
                DateTime endDate = new DateTime(2023, 12, 31);
                var allMonths = Enumerable.Range(1, 12);
                using (var ctx = new ECommerceAppDbContext())
                {
                    var item = await ctx.OrderDetails.Join(ctx.Orders, od => od.OrderId, o => o.OrderId, (od, o) => new { od, o }).
                        Where(x => x.o.OrderDate >= startDate && x.o.OrderDate <= endDate)
                        .GroupBy(x => new { x.o.OrderDate.Month, x.o.OrderDate.Year })
                         .Select(g => new MonthlyRevenuePerYearDTO
                         {
                             Month = g.Key.Month,
                             Year = g.Key.Year,
                             Revenue = g.Sum(x => x.od.TotalPrice)
                         })
                        .OrderBy(x => x.Year)
                        .ThenBy(x => x.Month)
                        .ToListAsync();
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

        public async Task AddOrderDetails(List<OrderDetail> list)
        {
            try
            {
                using (var ctx = new ECommerceAppDbContext())
                {

                    await ctx.OrderDetails.AddRangeAsync(list);
                    await ctx.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
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
