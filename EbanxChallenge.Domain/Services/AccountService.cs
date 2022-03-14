using EbanxChallenge.Domain.Models;
using EbanxChallenge.Domain.Repositories;

namespace EbanxChallenge.Domain.Services
{
    public class AccountService : IAccountService{
        private readonly IAccountRepository _accountRepository;
        private static int NextId { get; set; }
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<Account> Get(int accountId)
        {
            return await _accountRepository.Get(accountId);
        }

        public async Task Reset()
        {
            await _accountRepository.RemoveAll();
        }

        public async Task<decimal?> GetBalance(int accountId)
        {
            Account account = await _accountRepository.Get(accountId);
            if (account == null)
                return null;

            return account.GetBalance();
        }
    }
}