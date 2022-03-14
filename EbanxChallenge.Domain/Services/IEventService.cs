using EbanxChallenge.Domain.DTOs;

namespace EbanxChallenge.Domain.Services
{
    public interface IEventService {
        Task<EventOutputDTO?> Execute(EventInputDTO eventInputDTO);
    }
}