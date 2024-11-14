
using Microsoft.EntityFrameworkCore;

namespace EjermploConversorMoneda.Controllers;

public class CurrencyController : Controller {

    private readonly CurrencyConverterService _currencyConverterService;
    private readonly ApplicationDbContext _dbContext;


    public CurrencyController(ApplicationDbContext context, CurrencyConverterService currencyConverterService) {
        _currencyConverterService = currencyConverterService;
        _dbContext = context;
    }



    [HttpGet]
    public IActionResult Index() {

        var vm = new CurrencyConversionViewModel {
            Importe = 0m,
            listaMonedValid = _dbContext.Monedas.ToList(),
            Result = 0m,
        };

        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> Index(CurrencyConversionViewModel modelConveMoned) {

        // Optiene desde la BD los datos de la Moneda de origen solicitada
        var monedaOrigen = _dbContext.Monedas.FirstOrDefault(m => m.Codigo == modelConveMoned.MonedaOrigen);

        // Optiene desde la BD los datos de la Moneda de destino solicitada
        var monedaDestino = _dbContext.Monedas.FirstOrDefault(m => m.Codigo == modelConveMoned.MonedaDestino);

        // Obtiene los códigos de moneda origen y destino, y también el importe a convertir
        var codigoModenaOrigen = monedaOrigen.Codigo;
        var codigoModenaDestino = monedaDestino.Codigo;
        var importe = modelConveMoned.Importe.ToString();

        // Realiza la consulta respecto a los datos a convertir
        var resultadoConversion = await _currencyConverterService.ConvertCurrency(importe, codigoModenaOrigen, codigoModenaDestino);

        // Recoge los datos de la conversión
        modelConveMoned.Result = resultadoConversion.ConversionResult;
        modelConveMoned.RatioConversion = resultadoConversion.ConversionRate;

        modelConveMoned.listaMonedValid = _dbContext.Monedas.ToList();

        return View(modelConveMoned);
    }
}
