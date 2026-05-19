using System.Text.Json;
using CurrencyConverter.Web.Core.Entities;
using CurrencyConverter.Web.Core.Interfaces;

namespace CurrencyConverter.Web.Infrastructure.Adapters;

public class FawazAhmedExchangeAdapter(HttpClient httpClient) : IExchangeRateProvider
{
    public async Task<double> FetchExchangeRateAsync(ExchangeRate from, ExchangeRate to)
    {
        // should be refactored to not use ToString
        var baseCurrency =   from.ToString().ToLower();
        var targetCurrency = to.ToString().ToLower();

        var responseString = await httpClient.GetStringAsync($"currencies/{baseCurrency}.json");
        using var document = JsonDocument.Parse(responseString);

        if (document.RootElement.TryGetProperty(baseCurrency, out var ratesElement))
        {
            if (ratesElement.TryGetProperty(targetCurrency, out var rateElement))
            {
                return rateElement.GetDouble();
            }
        }

        throw new Exception($"Adapter failed to parse exchange rate for {targetCurrency}.");
    }
}