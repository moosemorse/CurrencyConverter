namespace CurrencyConverter.Web.Core.Interfaces;

public interface ICurrencyConverterService
{
    // responsible for logic of converting
    Task<double> getConversionAsync(IConverterInput input);
}