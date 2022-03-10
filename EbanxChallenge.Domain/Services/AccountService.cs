using EbanxChallenge.Domain.Repositories;

namespace EbanxChallenge.Domain.Services
{
    public class AccountService : IAccountService{
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }


        
    }
}