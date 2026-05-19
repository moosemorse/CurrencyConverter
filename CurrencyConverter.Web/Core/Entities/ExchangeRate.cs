namespace CurrencyConverter.Web.Core.Entities;

// another consideration, we make a class here to represent exchange rates instead of enum
// would avoid using hardcoded enums and then fetch possible exchange rates from api
public enum ExchangeRate
{
    GBP,
    EUR
}
 