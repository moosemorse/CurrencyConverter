namespace CurrencyConverter.Web.Core.Interfaces;

public interface ICurrencyNameProvider
{
    Task<Dictionary<string, string>> FetchCurrencyNamesAsync();
}