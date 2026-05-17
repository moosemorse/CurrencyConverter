namespace Frontend.Components.Models;

public class ConverterInput
{
    public ExchangeRate StartingRate { get; set; }
    public int Amount { get; set; }
    public ExchangeRate TargetRate { get; set; }

    // maybe useful: ArgumentException.ThrowIfNullOrEmpty(string paramName) for validation
    //               ArgumentException.ThrowIfNullOrWhitespace(string paramName) for string validation <-- acc i think this is already handled by blazor component
    
}