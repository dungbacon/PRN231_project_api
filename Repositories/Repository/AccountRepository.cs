using AutoMapper;
using e_commerce_app_api.DAO;
using e_commerce_app_api.DTOs;
using e_commerce_app_api.Models;

namespace e_commerce_app_api.Repositories.Repository
{
    public class AccountRepository : IAccountRepository
    {

        private readonly IMapper mapper;

        public AccountRepository(IMapper _mapper)
        {
            mapper = _mapper;
        }

        public async Task<AccountDTO> AddAccount(AccountDTO p)
        {
            var a = mapper.Map<Account>(p);
            return mapper.Map<AccountDTO>(await AccountDAO.Instance.AddAccount(a));
        }

        public Task DeleteAccount(int id) => AccountDAO.Instance.DeleteAccount(id);

        public async Task<AccountDTO> GetAccount(string email, string password) => mapper.Map<AccountDTO>(await AccountDAO.Instance.GetAccount(email, password));
        public async Task<AccountDTO> GetAccountByEmail(string email) => mapper.Map<AccountDTO>(await AccountDAO.Instance.GetAccountByEmail(email));

        public async Task<AccountDTO> GetAccountById(int id) => mapper.Map<AccountDTO>(await AccountDAO.Instance.GetAccountById(id));

        public async Task<List<AccountDTO>> GetAccounts() => mapper.Map<List<AccountDTO>>(await AccountDAO.Instance.GetAccounts());

        public async Task<AccountDTO> UpdateAccount(AccountDTO account, int id)
        {
            var a = mapper.Map<Account>(account);
            return mapper.Map<AccountDTO>(await AccountDAO.Instance.UpdateAccount(a, id));
        }
    }
}
