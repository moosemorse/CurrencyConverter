namespace CurrencyConverter.Web.Core.Interfaces;

public interface ICurrencyConverterService
{
    Task<double> getConversionAsync(IConverterInput input);
}