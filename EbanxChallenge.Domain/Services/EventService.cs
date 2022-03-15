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
            EventOutputDTO? eventOutputDTO = null;
            switch (eventInputDTO.Type) 
            {
                case nameof(EventType.deposit):
                    eventOutputDTO = await _accountService.Deposit(eventInputDTO);
                    break;
                case nameof(EventType.transfer):
                    eventOutputDTO = await _accountService.Transfer(eventInputDTO);
                    break;
                case nameof(EventType.withdraw):
                    eventOutputDTO = await _accountService.Withdraw(eventInputDTO);
                    break;
                default:
                    break;
            }

            return eventOutputDTO;
        }
        
    }
}