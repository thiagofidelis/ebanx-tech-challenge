using EbanxChallenge.Domain.Models;

namespace EbanxChallenge.Domain.Services
{
    public interface IAccountService {
        Task<Account> Get(int accountId);
        Task<decimal?> GetBalance(int accountId);
        Task Reset();
    }
}