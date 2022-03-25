using System.Xml;
using EmkPower.AddressApi.Models;

namespace EmkPower.AddressApi.Currency;

public class CurrencyService
{
    private readonly CurrencyCacheService _currencyCacheService;
    public CurrencyService(CurrencyCacheService currencyCacheService)
    {
        _currencyCacheService = currencyCacheService;
    }
    public CurrencyResult ConvertCurrency(Currencies baseCurrency, decimal baseValue)
    {
        var currencyResult = new CurrencyResult()
        {
            Base = baseCurrency,
            BaseValue = baseValue
        };
        var crossRatesList = new List<CurrencyRecord>();
        foreach (Currencies currency in Enum.GetValues(typeof(Currencies)))
        {
           var crossRate= _currencyCacheService.GetCrossCurrency(baseCurrency, currency, DateTime.Now);
           crossRatesList.Add(new CurrencyRecord()
           {
               CurrencyTitle = crossRate.TargetCurrency,
               CurrencyValue = decimal.Round(crossRate.RateValue * baseValue, 2, MidpointRounding.AwayFromZero)
           });
        }

        currencyResult.Values = crossRatesList;
        return currencyResult;
    }

   
}
