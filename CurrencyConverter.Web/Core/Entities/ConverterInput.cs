using System.ComponentModel.DataAnnotations;
using CurrencyConverter.Web.Core.Interfaces;

namespace CurrencyConverter.Web.Core.Entities;

public class ConverterInput : IConverterInput
{
    [Required]
    public required ExchangeRate StartingRate { get; set; }

    [Required(ErrorMessage = "Enter amount to convert")]
    [Range(0, double.MaxValue, ErrorMessage = "Amount must be a positive number")] // note: this doesn't handle 1E+200 and maybe don't want to allow huuuugee numbers + error message ugly
    public double? Amount { get; set; }
    [Required]
    public required ExchangeRate TargetRate { get; set; }

}