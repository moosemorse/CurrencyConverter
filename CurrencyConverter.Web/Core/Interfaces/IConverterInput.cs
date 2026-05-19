using CurrencyConverter.Web.Core.Entities;

namespace CurrencyConverter.Web.Core.Interfaces;

public interface IConverterInput
{
    ExchangeRate StartingRate { get; set; }
    double? Amount { get; set; }
    ExchangeRate TargetRate { get; set; }
}