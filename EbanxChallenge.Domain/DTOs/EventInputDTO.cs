using System.ComponentModel.DataAnnotations;
using EbanxChallenge.Domain.Enums;

namespace EbanxChallenge.Domain.DTOs
{
    public class EventInputDTO : IValidatableObject
    {
        public EventType Type { get; set; }
        public int? Origin { get; set; }
        public int? Destination { get; set; }
        public decimal? Amount { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            switch (Type) 
            {
                case EventType.Deposit:
                    if (Destination == null) 
                    { 
                        yield return new ValidationResult(
                        $"Destination is mandatory field.",
                        new[] { nameof(Destination) });
                    }
                    if (Amount == null) 
                    { 
                        yield return new ValidationResult(
                        $"Amount is mandatory field.",
                        new[] { nameof(Amount) });
                    }
                    break;
                case EventType.Transfer:
                    if (Origin == null) 
                    { 
                        yield return new ValidationResult(
                        $"Origin is mandatory field.",
                        new[] { nameof(Origin) });
                    }
                    if (Destination == null) 
                    { 
                        yield return new ValidationResult(
                        $"Destination is mandatory field.",
                        new[] { nameof(Destination) });
                    }
                    if (Amount == null) 
                    { 
                        yield return new ValidationResult(
                        $"Amount is mandatory field.",
                        new[] { nameof(Amount) });
                    }
                    break;
                case EventType.Withdraw:
                    if (Origin == null) 
                    { 
                        yield return new ValidationResult(
                        $"Origin is mandatory field.",
                        new[] { nameof(Origin) });
                    }
                    if (Amount == null) 
                    { 
                        yield return new ValidationResult(
                        $"Amount is mandatory field.",
                        new[] { nameof(Amount) });
                    }
                    break;
                default:
                    break;
            }
        }

    }
}