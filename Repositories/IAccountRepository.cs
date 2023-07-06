using e_commerce_app_api.DTOs;

namespace e_commerce_app_api.Repositories
{
    public interface IAccountRepository
    {
        Task<List<AccountDTO>> GetAccounts();
        Task<AccountDTO> GetAccountById(int id);
        Task<AccountDTO> GetAccount(string email, string password);
        Task<AccountDTO> GetAccountByEmail(string email);
        Task<AccountDTO> AddAccount(AccountDTO account);
        Task<AccountDTO> UpdateAccount(AccountDTO account, int id);
        Task DeleteAccount(int id);
    }
}
