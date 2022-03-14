using EbanxChallenge.Domain.DTOs;
using EbanxChallenge.Domain.Enums;
using EbanxChallenge.Domain.Models;

namespace EbanxChallenge.Domain.Services
{
    public class EventService : IEventService
    {
        private readonly IAccountService _accountService;
        public EventService(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<EventOutputDTO?> Execute(EventInputDTO eventInputDTO)
        {
            switch (eventInputDTO.Type) 
            {
                case EventType.Deposit:
                    break;
                case EventType.Transfer:
                    break;
                case EventType.Withdraw:
                    break;
                default:
                    break;
            }

            return new EventOutputDTO();
        }

        private async Task<EventOutputDTO> Transfer() 
        { 
            throw new NotImplementedException();
        }

        private async Task<EventOutputDTO> Withdraw()
        { 
            throw new NotImplementedException();
        }

        private async Task<EventOutputDTO> Deposit()
        {
            throw new NotImplementedException();
        }

        private async Task<EventOutputDTO> CreateAccount(EventInputDTO eventInputDTO)
        {
            throw new NotImplementedException();
        }
    }
}