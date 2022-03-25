using EmkPower.AddressApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmkPower.AddressApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CurrencyController : ControllerBase
{
    private readonly ILogger<CurrencyController> _logger;

    public CurrencyController(ILogger<CurrencyController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [Route("convert/{baseCurrency}/{value}")]
    public ActionResult<CurrencyResult> GetConvertedCurrency(string apiKey, string baseCurrency, decimal value)
    {

        if (!string.IsNullOrEmpty(baseCurrency))
        {
            var result = new CurrencyResult();
            result.Base = baseCurrency;
            result.Values = new List<CurrencyRecord>()
            {
                new CurrencyRecord()
                {
                    CurrencyTitle = "USD",
                    CurrencyValue = 15.50M
                }
            };
            return Ok(result);
            
        }

        return BadRequest("Eksik ya da hatali bir talepte bulundunuz");


    }
}