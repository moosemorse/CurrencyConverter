namespace Frontend.Components.Models;

public class ConverterInput
{
    public ExchangeRate? StartingRate { get; set; }
    public int? Amount { get; set; }
    public ExchangeRate? TargetRate { get; set; }
    
}