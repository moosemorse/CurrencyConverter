using System.Text.Json;
using CurrencyConverter.Web.Core.Interfaces;

namespace CurrencyConverter.Web.Infrastructure.Services;

/* 
    Some notes:
    - right now, our model is very simple and tracks all the required fields with minimal security and design
    - it will records inputs, handle submits, return result to home page

    Ideas:
    - separate class into separate stages i.e. class for input, class for processing, class for output (or records)
    - add validation to model for input
    - create interfaces for each stage
    - dependency injections for processing stage - making call to service/adapter for client api
    - im not sure if this is a c# thing but create separate namespaces for each stage (is everything a model?)
*/

// dependency injection for http client
public class CurrencyConverterService(HttpClient httpClient) : ICurrencyConverterService
{
    public async Task<double> getConversionAsync(IConverterInput input)
    {
        ArgumentNullException.ThrowIfNull(httpClient);
        ArgumentNullException.ThrowIfNull(input.Amount);
        
        // optimisations
        // if (input.StartingRate == input.TargetRate) return input.Amount.Value;

        // The API requires lowercase currency codes
        // I don't like this, we should make a mapping in the model
        var baseCurrency   = input.StartingRate.ToString().ToLower();
        var targetCurrency = input.TargetRate.ToString().ToLower();

        var url = $"https://cdn.jsdelivr.net/npm/@fawazahmed0/currency-api@latest/v1/currencies/{baseCurrency}.json";

        // Fetch and parse the dynamic JSON
        var responseString = await httpClient.GetStringAsync(url);
        using var document = JsonDocument.Parse(responseString);

        // Dig into the JSON to find the target rate
        if (document.RootElement.TryGetProperty(baseCurrency, out var ratesElement))
        {
            if (ratesElement.TryGetProperty(targetCurrency, out var rateElement))
            {
                var exchangeRate = rateElement.GetDouble();
                return input.Amount.Value * exchangeRate;
            }
        }

        throw new Exception($"Failed to fetch exchange rate for {targetCurrency}.");
    
    }
}