using System.ComponentModel.DataAnnotations;
using EbanxChallenge.Domain.Enums;

namespace EbanxChallenge.Domain.DTOs
{
    public class EventInputDTO : IValidatableObject
    {
        public string Type { get; init; }
        public string? Origin { get; set; }
        public string? Destination { get; set; }
        public decimal? Amount { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            switch (Type) 
            {
                case nameof(EventType.deposit):
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
                case nameof(EventType.transfer):
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
                case nameof(EventType.withdraw):
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