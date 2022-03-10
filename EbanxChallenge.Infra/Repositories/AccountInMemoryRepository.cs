using System.Linq.Expressions;
using EbanxChallenge.Domain.Models;
using EbanxChallenge.Domain.Repositories;

namespace EbanxChallenge.Infra.Repositories
{
    public class AccountInMemoryRepository : IAccountRepository
    {
        private IList<Account> accounts;
        public AccountInMemoryRepository()
        {
            accounts = new List<Account>();
        }

        public Task Add(Account entity)
        {
            throw new NotImplementedException();
        }

        public Task AddRange(IEnumerable<Account> entities)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Account>> Find(Expression<Func<Account, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Account> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Account>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Remove(Account entity)
        {
            throw new NotImplementedException();
        }

        public Task RemoveRange(IEnumerable<Account> entities)
        {
            throw new NotImplementedException();
        }
    }
}