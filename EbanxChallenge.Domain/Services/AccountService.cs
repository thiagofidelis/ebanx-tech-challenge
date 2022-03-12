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

        public Task<Account> Get(int accountId)
        {
            return _accountRepository.Get(accountId);
        }
    }
}