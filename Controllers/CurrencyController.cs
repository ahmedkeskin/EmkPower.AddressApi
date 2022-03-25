using EmkPower.AddressApi.Currency;
using EmkPower.AddressApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmkPower.AddressApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CurrencyController : ControllerBase
{
    private readonly ILogger<CurrencyController> _logger;
    private readonly CurrencyService _currencyService;

    public CurrencyController(ILogger<CurrencyController> logger, CurrencyService currencyService)
    {
        _logger = logger;
        _currencyService = currencyService;
    }

    [HttpGet]
    [Route("convert/{baseCurrency}/{value}")]
    public ActionResult<CurrencyResult> GetConvertedCurrency(string apiKey, Currencies baseCurrency, decimal value)
    {
        try
        {
            var result= _currencyService.ConvertCurrency(baseCurrency, value);
            return Ok(result);
        }
        catch 
        {
            return BadRequest("Eksik ya da hatali bir talepte bulundunuz");
        }
      


    }
}