using EbanxChallenge.Domain.DTOs;
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

        public async Task<Account> Get(string accountId)
        {
            return await _accountRepository.Get(accountId);
        }

        public async Task Reset()
        {
            await _accountRepository.RemoveAll();
        }

        public async Task<decimal?> GetBalance(string accountId)
        {
            Account account = await _accountRepository.Get(accountId);
            if (account == null)
                return null;

            return account.Balance;
        }

        public async Task<EventOutputDTO?> Transfer(EventInputDTO eventInputDTO) 
        { 
            decimal amount = eventInputDTO.Amount.GetValueOrDefault();
            

            EventOutputDTO? resultDepositDTO = null;
            Account originAccount = await _accountRepository.Get(eventInputDTO.Origin!);
            Account destinationAccount = await _accountRepository.Get(eventInputDTO.Destination!);

            // only do the transfer if origin account exist
            if (originAccount != null) {

                originAccount.Debit(amount);

                // if destination account doesn't exist we create it
                if (destinationAccount != null)
                    destinationAccount.Credit(amount);
                else
                    destinationAccount = await CreateAccount(eventInputDTO.Destination!, amount);

                resultDepositDTO = new EventOutputDTO()
                {
                    Origin = originAccount,
                    Destination = destinationAccount
                };
            }

            return resultDepositDTO;
        }

        public async Task<EventOutputDTO?> Withdraw(EventInputDTO eventInputDTO)
        { 
            EventOutputDTO? resultDepositDTO = null;

            Account depositAccount = await _accountRepository.Get(eventInputDTO.Origin!);

            if (depositAccount != null)
            {
                depositAccount.Debit(eventInputDTO.Amount.GetValueOrDefault());
                resultDepositDTO = new EventOutputDTO()
                {
                    Origin = depositAccount
                };
            }

            return resultDepositDTO;
        }

        public async Task<EventOutputDTO> Deposit(EventInputDTO eventInputDTO)
        {
            Account depositAccount = await _accountRepository.Get(eventInputDTO.Destination!);

            // create new account
            if (depositAccount == null)
            {
                Account newAccount = await CreateAccount(eventInputDTO.Destination!, eventInputDTO.Amount.GetValueOrDefault());
                
                var resultNewAccountDTO = new EventOutputDTO()
                {
                    Destination = newAccount

                };

                return resultNewAccountDTO;
            }

            // just a deposit
            depositAccount.Credit(eventInputDTO.Amount.GetValueOrDefault());
            var resultDepositDTO = new EventOutputDTO()
            {
                Destination = depositAccount
            };

            return resultDepositDTO;
        }

        public async Task<Account> CreateAccount(string id, decimal ammount)
        {
            var newAccount = new Account(id, ammount);
            await _accountRepository.Add(newAccount);

            return newAccount;
        }
    }
}