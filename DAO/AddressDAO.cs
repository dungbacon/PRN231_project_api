using e_commerce_app_api.Models;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_app_api.DAO
{
    public class AddressDAO
    {
        private static AddressDAO instance;

        private AddressDAO() { }
        public static AddressDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AddressDAO();
                }
                return instance;
            }
        }

        public async Task<List<Address>?> GetList()
        {
            try
            {
                using (var ctx = new ECommerceAppDbContext())
                {
                    var list = await ctx.Addresses.ToListAsync();
                    return list;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<List<Address>?> GetListByCustomer(int customerId)
        {
            try
            {
                using (var ctx = new ECommerceAppDbContext())
                {
                    var list = await ctx.Addresses.Where(s => s.AccountId == customerId).ToListAsync();
                    return list;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<Address?> GetAddressById(int addressId)
        {
            try
            {
                using (var ctx = new ECommerceAppDbContext())
                {
                    var item = await ctx.Addresses.Where(s => s.AddressId == addressId).FirstOrDefaultAsync();
                    return item;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<Address?> AddAddress(Address input)
        {
            try
            {
                using (var ctx = new ECommerceAppDbContext())
                {
                    input.CreateDate = DateTime.Now;
                    input.UpdatedDate = DateTime.Now;
                    ctx.Addresses.Add(input);
                    await ctx.SaveChangesAsync();
                    return await ctx.Addresses.Where(s => s.AddressId == input.AddressId).FirstOrDefaultAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public async Task<Address?> UpdateAddress(Address input)
        {
            try
            {
                using (var ctx = new ECommerceAppDbContext())
                {
                    input.UpdatedDate = DateTime.Now;
                    ctx.Entry<Address>(input).State = EntityState.Modified;
                    await ctx.SaveChangesAsync();
                    return await ctx.Addresses.Where(s => s.AddressId == input.AddressId).FirstOrDefaultAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task DeleteAddress(int id)
        {
            try
            {
                using (var ctx = new ECommerceAppDbContext())
                {
                    var item = await ctx.Addresses.FirstOrDefaultAsync(s => s.AddressId == id);
                    ctx.Addresses.Remove(item);
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
