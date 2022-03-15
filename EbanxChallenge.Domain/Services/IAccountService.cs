using EbanxChallenge.Domain.DTOs;
using EbanxChallenge.Domain.Models;

namespace EbanxChallenge.Domain.Services
{
    public interface IAccountService {
        Task<Account> Get(string accountId);
        Task<decimal?> GetBalance(string accountId);
        Task Reset();
        Task<EventOutputDTO?> Transfer(EventInputDTO eventInputDTO);
        Task<EventOutputDTO> Deposit(EventInputDTO eventInputDTO);
        Task<EventOutputDTO?> Withdraw(EventInputDTO eventInputDTO);
    }
}