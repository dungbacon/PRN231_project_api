using e_commerce_app_api.DTOs;
using e_commerce_app_api.DTOs.Request;
using e_commerce_app_api.DTOs.Response;
using e_commerce_app_api.Models;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_app_api.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        private AccountDAO() { }
        public static AccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AccountDAO();
                }
                return instance;
            }
        }

        public async Task<List<Account>?> GetAccounts()
        {
            var list = new List<Account>();
            try
            {
                using (var ctx = new ECommerceAppDbContext())
                {
                    list = await ctx.Accounts.Where(s => s.IsActive == true).ToListAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return list;
        }

        public async Task<AccountDetailDTO?> GetAccountById(int id)
        {
            try
            {
                using (var ctx = new ECommerceAppDbContext())
                {
                    var item = await ctx.Accounts
                        .Include(s => s.Orders)
                        .ThenInclude(s => s.OrderDetails)
                        .Where(s => s.AccountId == id && s.IsActive == true)
                        .Select(s => new AccountDetailDTO
                        {
                            AccountId = s.AccountId,
                            FullName = s.FullName,
                            Email = s.Email,
                            Password = s.Password,
                            Phone = s.Phone,
                            Orders = (List<OrderResponseDTO>)s.Orders!.Select(a => new OrderResponseDTO
                            {
                                OrderDate = a.OrderDate,
                                ShippedDate = a.ShippedDate,
                                TotalPrice = a.OrderDetails!.Sum(z => z.TotalPrice)
                            })
                        })
                        .FirstOrDefaultAsync();

                    return item;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<Account?> GetAccount(string email, string password)
        {
            var item = new Account();
            try
            {
                using (var ctx = new ECommerceAppDbContext())
                {
                    item = await ctx.Accounts.Where(s => s.Email == email && s.Password == password && s.IsActive == true).Include(s => s.Role).FirstOrDefaultAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return item;
        }

        public async Task<Account?> GetAccountByEmail(string email)
        {
            var item = new Account();
            try
            {
                using (var ctx = new ECommerceAppDbContext())
                {
                    item = await ctx.Accounts.Where(s => s.Email == email && s.IsActive == true).FirstOrDefaultAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return item;
        }

        public async Task<Account?> AddAccount(Account account)
        {
            try
            {
                using (var ctx = new ECommerceAppDbContext())
                {
                    ctx.Accounts.Add(account);
                    await ctx.SaveChangesAsync();
                    return await ctx.Accounts.Where(s => s.AccountId == account.AccountId && s.IsActive == true).FirstOrDefaultAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public async Task<Account?> UpdateAccount(AccountRequestUpdateDTO account, int id)
        {
            try
            {
                using (var ctx = new ECommerceAppDbContext())
                {
                    var item = await ctx.Accounts.FirstOrDefaultAsync(s => s.AccountId == id && s.IsActive == true);
                    if (item != null)
                    {
                        item.FullName = account.FullName;
                        item.Email = account.Email;
                        item.Password = account.Password;
                        item.Phone = account.Phone;
                        item.UpdatedDate = DateTime.Now;
                        ctx.Entry<Account>(item).State = EntityState.Modified;
                        await ctx.SaveChangesAsync();
                    }

                    return item;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public async Task DeleteAccount(int id)
        {
            var item = new Account();
            try
            {
                using (var ctx = new ECommerceAppDbContext())
                {
                    item = await ctx.Accounts.Where(s => s.AccountId == id).FirstOrDefaultAsync();
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
