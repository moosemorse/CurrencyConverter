using CurrencyConverter.Web.Core.Interfaces;

namespace CurrencyConverter.Web.Infrastructure.Services;

public class PrettyPrintService(ICurrencyNameProvider currencyNameProvider) : IPrettyPrintService
{
    private Dictionary<string, string>? _cachedNames;

    public async Task<Dictionary<string, string>> GetAllCurrencyNamesAsync()
    {
        if (_cachedNames != null) return _cachedNames;
        
        _cachedNames = await currencyNameProvider.FetchCurrencyNamesAsync();

        return _cachedNames;
    }
}