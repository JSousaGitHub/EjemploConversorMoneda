

namespace EjermploConversorMoneda.Models;

public class CurrencyConversionViewModel {

    public CurrencyConversionViewModel() {
        // Inicializar las propiedades con un valor por defecto
        listaMonedValid = new List<Moneda>();
    }

    // Lista de códigos de moneda válidos
    [BindNever]
    public List<Moneda> listaMonedValid { get; set; }

    // Marcador de error
    public bool error { get; set; }

    // Mensaje del error
    public string msg { get; set; }

    // La cantidad de dinero que el usuario quiere convertir
    [Required(ErrorMessage = "El importe es obligatorio.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El importe debe ser mayor que 0")]
    [Display(Name = "Importe a convertir")]
    public decimal Importe { get; set; }

    // La divisa de origen que el usuario quiere convertir
    [Required(ErrorMessage = "La moneda de origen es obligatoria.")]
    [StringLength(3, ErrorMessage = "La divisa de origen debe ser de 3 caracteres")]
    [Display(Name = "Moneda de origen")]
    public string MonedaOrigen { get; set; }


    // La divisa de destino a la que el usuario quiere convertir
    [Required(ErrorMessage = "La moneda de destino es obligatoria.")]
    [StringLength(3, ErrorMessage = "La divisa de destino debe ser de 3 caracteres")]
    [Display(Name = "Moneda de destino")]
    public string MonedaDestino { get; set; }

    // El resultado de la conversión de divisa
    public decimal Result { get; set; }

    // TODO: ---> Mirar si es necesario este código
    // Importe convertido
    //public decimal ImporteConvertido { get; set; }
    public decimal RatioConversion { get; set; }
    // public string? CorreoUsuario { get; set; }
    public int ClienteId { get; internal set; }
}








