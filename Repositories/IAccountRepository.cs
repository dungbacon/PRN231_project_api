using e_commerce_app_api.DTOs;
using e_commerce_app_api.DTOs.Request;

namespace e_commerce_app_api.Repositories
{
    public interface IAccountRepository
    {
        Task<List<AccountDTO>> GetAccounts();
        Task<AccountDetailDTO> GetAccountById(int id);
        Task<AccountDTO> GetAccount(string email, string password);
        Task<AccountDTO> GetAccountByEmail(string email);
        Task<AccountDTO> AddAccount(AccountDTO account);
        Task<AccountDTO> UpdateAccount(AccountRequestUpdateDTO account, int id);
        Task DeleteAccount(int id);
    }
}
