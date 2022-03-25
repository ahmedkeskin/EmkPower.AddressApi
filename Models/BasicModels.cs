using System.Text.Json.Serialization;
using EmkPower.AddressApi.Currency;

namespace EmkPower.AddressApi.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public string Description { get; set; }
    }

    public class District
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Address> AddressList { get; set; }
    }

    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<District> DistrictList { get; set; }
    }

    public class Root
    {
        public List<City> Cities { get; set; }
        public List<CrossRate> CrossRates { get; set; }
    }

    public class CrossRate
    {
        public Currencies BaseCurrency { get; set; }
        public List<CurrencyRecord> Rates { get; set; }

    }
    
    public class CurrencyResult
    {
        public Currencies Base { get; set; }
        public decimal BaseValue { get; set; }

        public List<CurrencyRecord> Values { get; set; }
    }

    public class CurrencyRecord
    {
        public Currencies CurrencyTitle { get; set; }
        public decimal CurrencyValue { get; set; }
    }

    public class CrossCurrency
    {
        public Currencies BaseCurrency { get; set; }
        public Currencies TargetCurrency { get; set; }
        public decimal RateValue { get; set; }
    }
}