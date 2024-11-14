
namespace EjermploConversorMoneda.Entidades;

[Table("Clientes")]
public class Cliente {

    [Key]		// Clave primaria
    public int Id { get; set; }

    // Nombre del cliente
    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres.")]
    public string Nombre { get; set; } = string.Empty;

    // Correo electrónico del cliente.
    [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
    [EmailAddress(ErrorMessage = "Debe ser un correo electrónico válido.")]
    [StringLength(150, ErrorMessage = "El correo electrónico no puede tener más de 150 caracteres.")]
    public string Correo { get; set; } = string.Empty;

    // Fecha de nacimiento del cliente.
    [DataType(DataType.Date)]
    public DateTime? FechaNacimiento { get; set; }

    // Clave Foránea hacia Pais
    [ForeignKey("Pais")]
    public int? PaisId { get; set; }

    // País del cliente 
    public Pais? Pais { get; set; }

    // Identificador único del usuario
    public string? IdentityUserId { get; set; }

}

