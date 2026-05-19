using CurrencyConverter.Web.Core.Interfaces;

namespace CurrencyConverter.Web.Infrastructure.Services;

public class PrettyPrintService(ICurrencyNameProvider currencyNameProvider) : IPrettyPrintService
{
        // We cache the dictionary so we only fetch it from the internet ONCE per session
    private Dictionary<string, string>? _cachedNames;

    public async Task<Dictionary<string, string>> GetAllCurrencyNamesAsync()
    {
        if (_cachedNames != null) return _cachedNames;
        
        _cachedNames = await currencyNameProvider.FetchCurrencyNamesAsync();
        
        return _cachedNames;
    }
}