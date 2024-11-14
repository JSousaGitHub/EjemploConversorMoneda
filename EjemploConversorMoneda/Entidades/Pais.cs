
namespace EjermploConversorMoneda.Entidades;

[Table("Paises")]
public class Pais {

    [Key]   // Clave primaria
    public int Id { get; set; }

    // Nombre del país
    [Required(ErrorMessage = "El nombre del país es obligatorio.")]
    [StringLength(100, ErrorMessage = "El nombre del país no puede tener más de 100 caracteres.")]
    [Display(Name = "Nombre del país")]
    public string Nombre { get; set; } = string.Empty;

    // Còdigo del país
    [Required(ErrorMessage = "El código ISO del país es obligatorio.")]
    [StringLength(3, ErrorMessage = "El código ISO debe tener 3 caracteres.")]
    [Display(Name = "Código ISO")]
    public string CodigoISO { get; set; } = string.Empty;

    // Relación de Clientes
    public ICollection<Cliente> Clientes { get; set; }

    // Capital del país
    [StringLength(100)]
    [Display(Name = "Capital")]
    public string? Capital { get; set; } = string.Empty;

    // Prefijo telefónico
    [Display(Name = "Prefijo Telefónico")]
    public string? PrefijoTelefonico { get; set; } = string.Empty;
}
