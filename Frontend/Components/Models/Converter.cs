namespace Frontend.Components.Models;

public class Converter
{
    public required ExchangeRate StartingRate { get; set; }
    public required int Amount { get; set; }
    public required ExchangeRate TargetRate { get; set; }
}