
namespace EjermploConversorMoneda.Entidades;

public class CurrencyQuery {

    public int Id { get; set; }
    public string FromCurrency { get; set; }
    public string ToCurrency { get; set; }
    public decimal Amount { get; set; }
    public decimal Result { get; set; }
    public DateTime QueryDate { get; set; }
}
