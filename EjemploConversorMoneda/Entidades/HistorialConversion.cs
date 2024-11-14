
namespace EjermploConversorMoneda.Entidades;

[Table("HistorialConversiones")]
public class HistorialConversion {

    [Key]		// Clave primaria
    public int Id { get; set; }

    [Required] 	// Cliente que utilizó el servicio
    [ForeignKey("Cliente")]
    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; }

    [Required] 	// Moneda Convertida
    [ForeignKey("MonedaOrigen")]
    public int MonedaOrigenId { get; set; }
    public Moneda MonedaOrigen { get; set; }

    [Required] 	// Moneda referencia
    [ForeignKey("MonedaDestino")]
    public int MonedaDestinoId { get; set; }
    public Moneda MonedaDestino { get; set; }

    [Required] 	// Factor de conversión utilizado
    [Column(TypeName = "decimal(18, 6)")]
    public decimal FactorConversionUsado { get; set; }

    [Required] 	// Inporte en unidades de moneda origen
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Importe { get; set; }

    [Required] 	// Inporte resultante en unidades de moneda destino
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Resultado { get; set; }

    // Fecha en la que se realizó la conversión
    public DateTime FechaConversion { get; set; } = DateTime.Now;
}
