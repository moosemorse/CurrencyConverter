using CurrencyConverter.Web.Core.Interfaces;

namespace CurrencyConverter.Web.Infrastructure.Services;

public class CurrencyConverterService(IExchangeRateProvider provider) : ICurrencyConverterService
{
    public async Task<double> getConversionAsync(IConverterInput input)
    {
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(input.Amount);

        var exchangeRate = await provider.FetchExchangeRateAsync(input.StartingRate, input.TargetRate);
        
        return input.Amount.Value * exchangeRate;
    }
}