using System.Xml;
using EmkPower.AddressApi.Mock;
using EmkPower.AddressApi.Models;

namespace EmkPower.AddressApi.Currency;

public class CurrencyCacheService
{
    private readonly string _cacheFolderPath;
    private readonly MockService _mockService;


    public CurrencyCacheService(MockService mockService)
    {
        _mockService = mockService;
        _cacheFolderPath = "cacheFolderPath";
    }

    public CrossCurrency GetCrossCurrency(Currencies baseCurrency, Currencies targetCurrency, DateTime date)
    {
        var crossRates = _mockService.GetCrossRates();
        var rate = crossRates.Where(w => w.BaseCurrency == baseCurrency).FirstOrDefault();
        var rateValue = rate.Rates.Where(w => w.CurrencyTitle == targetCurrency).FirstOrDefault().CurrencyValue;
        var result = new CrossCurrency()
            {BaseCurrency = baseCurrency, TargetCurrency = targetCurrency, RateValue = rateValue};
        return result;
    }
}