using System.ComponentModel.DataAnnotations;

namespace Frontend.Components.Models;

/* This might not be necessary but for now from tutorial it seems useful
   - Add attributes for validation
    - [Required] : this is required
    - [StringLength(n)] : this is a string with a length constraint of n
    - [Range(min, max)] : this is a number with a range constraint of min to max
    - [RegularExpression(pattern)] : this is a string that must match the regex pattern
    - [EmailAddress] : this is a string that must be a valid email address
    - [Phone] : this is a string that must be a valid phone number
    - [Url] : this is a string that must be a valid URL
    - [Compare(otherProperty)] : this property must match the value of otherProperty
    - [CustomValidation(typeof(ValidatorClass), "ValidationMethod")] : this property must pass
*/
public class ConverterInput
{
    [Required] // blazor makes sure user fills in field
    public required ExchangeRate StartingRate { get; set; }
    [Required]
    public required int Amount { get; set; }
    [Required]
    public required ExchangeRate TargetRate { get; set; }

    // maybe useful: ArgumentException.ThrowIfNullOrEmpty(string paramName) for validation
    //               ArgumentException.ThrowIfNullOrWhitespace(string paramName) for string validation <-- acc i think this is already handled by blazor component
    
}