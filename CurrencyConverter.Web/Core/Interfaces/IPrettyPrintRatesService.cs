namespace CurrencyConverter.Web.Core.Interfaces;

public interface IPrettyPrintService
{
    // Fetches the entire dictionary of currency codes to english names
    Task<Dictionary<string, string>> GetAllCurrencyNamesAsync();
}