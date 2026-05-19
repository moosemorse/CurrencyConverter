using CurrencyConverter.Web.Core.Interfaces;

namespace CurrencyConverter.Web.Infrastructure.Adapters;

public class FawazAhmedNameAdapter(HttpClient httpClient) : ICurrencyNameProvider
{
    public async Task<Dictionary<string, string>> FetchCurrencyNamesAsync()
    {
        var response = await httpClient.GetFromJsonAsync<Dictionary<string, string>>("currencies.json");
        return response ?? new Dictionary<string, string>();
    }
}