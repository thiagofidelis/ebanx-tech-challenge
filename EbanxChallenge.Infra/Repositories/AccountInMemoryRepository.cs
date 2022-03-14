using System.Linq.Expressions;
using EbanxChallenge.Domain.Models;
using EbanxChallenge.Domain.Repositories;

namespace EbanxChallenge.Infra.Repositories
{
    public class AccountInMemoryRepository : IAccountRepository
    {
        private List<Account> _accounts;
        private readonly object accountsLock = new object();
        public AccountInMemoryRepository()
        {
            _accounts = new List<Account>();
        }

        public async Task Add(Account account)
        {
            lock (accountsLock)
            {
                _accounts.Add(account);
            }
        }

        public async Task<Account?> Find(Predicate<Account> predicate)
        {
            lock (accountsLock)
            {
                return _accounts.Find(predicate);
            }
        }

        public async Task<Account?> Get(int id)
        {
            lock (accountsLock)
            {
                return _accounts.Find(a => a.Id == id);
            }
        }

        public async Task<IEnumerable<Account>> GetAll()
        {
            lock (accountsLock)
            {
                return _accounts;
            }
        }

        public async Task Remove(Account account)
        {
            lock (accountsLock)
            {
                _accounts.Remove(account);
            }
        }

        public async Task RemoveAll()
        {
            lock (accountsLock) { 
                _accounts.Clear();
            }
        }
    }
}