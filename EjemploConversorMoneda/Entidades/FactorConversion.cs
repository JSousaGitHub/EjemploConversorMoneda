
namespace EjermploConversorMoneda.Entidades;

[Table("FactoresConversion")]
public class FactorConversion {

    [Key]       // Clave primaria
    public int Id { get; set; }

    [Required]  // Moneda a Convertir
    [ForeignKey("MonedaOrigen")]
    public int MonedaOrigenId { get; set; }
    public Moneda MonedaOrigen { get; set; }

    [Required]  // Moneda referencia
    [ForeignKey("MonedaDestino")]
    public int MonedaDestinoId { get; set; }
    public Moneda MonedaDestino { get; set; }

    [Required]  // Factor de conversión
    [Column(TypeName = "decimal(18, 6)")]
    public decimal Factor { get; set; }

    // Fecha en la que se actualizó el factor
    public DateTime FechaActualizacion { get; set; } = DateTime.Now;
}

