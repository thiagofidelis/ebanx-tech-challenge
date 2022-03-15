using System.Text.Json.Serialization;
using EbanxChallenge.Domain.Models;

namespace EbanxChallenge.Domain.DTOs
{
    public class EventOutputDTO
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Account? Origin { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Account? Destination { get; set; }

    }
}