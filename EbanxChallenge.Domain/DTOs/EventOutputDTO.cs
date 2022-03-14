using EbanxChallenge.Domain.Models;

namespace EbanxChallenge.Domain.DTOs
{
    public class EventOutputDTO
    {
        public Account? Destination { get; set; }
        public Account? Origin { get; set; }

    }
}