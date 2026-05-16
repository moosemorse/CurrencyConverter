namespace Frontend.Models;

public class Converter
{

    // Im not sure about how project structure works in c#
    // ideally I want this in separate file
    public enum ExchangeRate
    {
        GBP,
        EUR
    }

    public required ExchangeRate startingRate;
    public required int amount;
    public required ExchangeRate targetRate;
}