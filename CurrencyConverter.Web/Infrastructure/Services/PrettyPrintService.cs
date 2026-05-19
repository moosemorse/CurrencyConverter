using CurrencyConverter.Web.Core.Interfaces;

namespace CurrencyConverter.Web.Infrastructure.Services;

public class PrettyPrintService(HttpClient httpClient) : IPrettyPrintService
{
    // We cache the dictionary so we only fetch it from the internet ONCE per session
    private Dictionary<string, string>? _cachedNames;

    private readonly string url = "https://cdn.jsdelivr.net/npm/@fawazahmed0/currency-api@latest/v1/currencies.json";

    public async Task<Dictionary<string, string>> GetAllCurrencyNamesAsync()
    {
        if (_cachedNames != null) return _cachedNames;
        
        _cachedNames = await httpClient.GetFromJsonAsync<Dictionary<string, string>>(url) 
                       ?? new Dictionary<string, string>();
                       
        return _cachedNames;
    }
}