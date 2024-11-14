
namespace EjermploConversorMoneda.Entidades;

[Table("Monedas")]
public class Moneda {

    [Key]   // Clave primaria
    public int Id { get; set; }

    // Nombre de la moneda
    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres.")]
    public string Nombre { get; set; } = string.Empty;

    // Código de la moneda
    [Required(ErrorMessage = "El código es obligatorio.")]
    [StringLength(10, ErrorMessage = "El código no puede tener más de 10 caracteres.")]
    public string Codigo { get; set; } = string.Empty;

    // Símbolo de la moneda
    [Required(ErrorMessage = "El símbolo es obligatorio.")]
    [StringLength(5, ErrorMessage = "El símbolo no puede tener más de 5 caracteres.")]
    public string Simbolo { get; set; } = string.Empty;
}
