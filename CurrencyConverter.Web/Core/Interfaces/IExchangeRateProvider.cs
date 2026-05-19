using CurrencyConverter.Web.Core.Entities;

namespace CurrencyConverter.Web.Core.Interfaces;

public interface IExchangeRateProvider
{
    // this only fetches the exchange rate between the 2 currencies
    Task<double> FetchExchangeRateAsync(ExchangeRate from, ExchangeRate to);
}