

namespace EjermploConversorMoneda.Contexto;

public class ApplicationDbContext : DbContext {

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) {
    }

    //     PROPIEDADES
    //--------------------------- 
    // Obtiene o establece los conjuntos de entidades que representan tablas en la base de datos.
    public DbSet<Moneda> Monedas { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Pais> Paises { get; set; }
    public DbSet<FactorConversion> FactoresConversion { get; set; }
    public DbSet<HistorialConversion> HistorialConversiones { get; set; }


    //     CONSTRUCTOR
    //--------------------------- 
    protected override void OnModelCreating(ModelBuilder modelBuilder) {

        // Llamada al método base
        base.OnModelCreating(modelBuilder);


        //     RESTRICCIONES DE ENTIDAD Moneda
        //-------------------------------------------
        // Configuración de la propiedad "Nombre" de la entidad "Moneda":
        modelBuilder.Entity<Moneda>()
            .Property(m => m.Nombre)
            .HasMaxLength(100)              // Longitud máxima de 100
            .IsRequired();                  // Marca el campo como obligatorio. No puede contener valores nulos.

        // Configuración de la propiedad "Codigo" de la entidad "Moneda":
        modelBuilder.Entity<Moneda>()
            .Property(m => m.Codigo)
            .HasMaxLength(10)               // Longitud máxima de 10
            .IsRequired();					// Marca el campo como obligatorio. No puede contener valores nulos.

        // Configuración de la propiedad "Simbolo" de la entidad "Moneda":
        modelBuilder.Entity<Moneda>()
           .Property(m => m.Simbolo)
           .HasMaxLength(5)				// Longitud máxima de 5
           .IsRequired();                   // Marca el campo como obligatorio. No puede contener valores nulos.



        //     RESTRICCIONES DE ENTIDAD Cliente
        //-------------------------------------------
        // Configuración de la relación entre Cliente y Pais
        modelBuilder.Entity<Cliente>()
            .HasOne(c => c.Pais)                    // Cada cliente tiene un país.
            .WithMany(p => p.Clientes)          // Un país puede tener múltiples clientes.
            .HasForeignKey(c => c.PaisId)       // Clave foránea en Cliente.
            .OnDelete(DeleteBehavior.NoAction);     // Evita la eliminación en cascada



        //     RESTRICCIONES DE ENTIDAD FactorConversion
        //---------------------------------------------------
        // Configuración de la relación entre FactorConversion y Moneda para MonedaOrigen
        modelBuilder.Entity<FactorConversion>()
            .HasOne(fc => fc.MonedaOrigen)      // Factor de conversión tiene una moneda de origen.
            .WithMany()                                 // No se especifican dependientes de MonedaOrigen
            .HasForeignKey(fc => fc.MonedaOrigenId)     // Clave foránea en FactorConversion.
            .OnDelete(DeleteBehavior.NoAction);     // Evita la eliminación en cascada

        // Configuración de la relación entre FactorConversion y Moneda para MonedaDestino
        modelBuilder.Entity<FactorConversion>()
            .HasOne(fc => fc.MonedaDestino)         // Factor de conversión tiene una moneda de destino.
            .WithMany()                                 // No se especifican dependientes de MonedaDestino
            .HasForeignKey(fc => fc.MonedaDestinoId)    // Clave foránea en FactorConversion.
            .OnDelete(DeleteBehavior.NoAction);     // Evita la eliminación en cascada



        //     RESTRICCIONES DE ENTIDAD HistorialConversion
        //------------------------------------------------------
        // Relación entre HistorialConversion y Cliente
        modelBuilder.Entity<HistorialConversion>()
            .HasOne(hc => hc.Cliente)           // Cada historial de conversión tiene un cliente.
            .WithMany()                                 // No se especifican dependientes en Cliente
            .HasForeignKey(hc => hc.ClienteId)  // Clave foránea en HistorialConversion.
            .OnDelete(DeleteBehavior.NoAction);     // Evita la eliminación en cascada

        // Relación entre HistorialConversion y Moneda para MonedaOrigen
        modelBuilder.Entity<HistorialConversion>()
            .HasOne(hc => hc.MonedaOrigen)      // Cada historial de conversión tiene una moneda de origen.
            .WithMany()                                 // No se especifican dependientes en MonedaOrigen
            .HasForeignKey(hc => hc.MonedaOrigenId)     // Clave foránea en HistorialConversion.
            .OnDelete(DeleteBehavior.NoAction);     // Evita la eliminación en cascada

        // Relación entre HistorialConversion y Moneda para MonedaDestino
        modelBuilder.Entity<HistorialConversion>()
            .HasOne(hc => hc.MonedaDestino)         // Cada historial de conversión tiene una moneda de destino.
            .WithMany()                                 // No se especifican dependientes en MonedaDestino
            .HasForeignKey(hc => hc.MonedaDestinoId)    // Clave foránea en HistorialConversion.
            .OnDelete(DeleteBehavior.NoAction);     // Evita la eliminación en cascada
    }
}

